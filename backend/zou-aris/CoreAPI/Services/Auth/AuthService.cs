using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CoreAPI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly HelperFunctions _helper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContext;   
        private readonly IConfiguration _config;
        private readonly ResponseDto _response;

        public AuthService(UserManager<User> userManager,RoleManager<Role> roleManager,ResponseDto response,HelperFunctions helper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContext,IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
            _helper = helper;
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
            _config = configuration;
            _response = response;   
        }
        public async Task<ResponseDto> ChangePassword(ChangePasswordDto dto)
        {
            var name = _httpContext.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);

            if (user == null)
            {
                _response.Status = false;
                _response.Message = "User not found";
            }
            else
            {
                var actionrespond = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
                var expiredperiod = _config.GetSection("PASSWORDEXPIRY").Value;
                user.PasswordExpiry = DateTime.Now.AddDays(double.Parse(expiredperiod)).ToUniversalTime();
                await _userManager.UpdateAsync(user);

                if (actionrespond.Succeeded)
                {
                    _response.Status = true;
                    _response.Message = "Password successfully changed";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Password change failed";
                }
            }

            return _response;
        }

        public async Task<ProfileReponse> FormateProfile(User user, IList<string> roles)
        {
            bool passwordexpired = false;
            if (user.PasswordExpiry == null || DateTime.Compare((DateTime)user.PasswordExpiry, DateTime.Now) <= 0)
            {
                passwordexpired = true;
            }
            IList<RoleviewDto> rolesList = new List<RoleviewDto>();
            foreach (var role in roles)
            {

                var dbrole = await _roleManager.FindByNameAsync(role);
                if (dbrole != null)
                {
                    var menu = GenerateMainmenu(dbrole);
                    rolesList.Add(new RoleviewDto { Name = dbrole.Name, View = dbrole.View,mainmenu=menu.ToList() });
                }

            }
            var profileResponse = new ProfileReponse() { Id = user.Id, Name = user.Name, Surname = user.Surname, Username = user.UserName, Email = user.Email, Status = user.Status, Role = rolesList, Passwordexpired = passwordexpired };
            return profileResponse;
        }

        public IList<MainmenuDto> GenerateMainmenu(Role role)
        {
            IList<MainmenuDto> mainmenus = new List<MainmenuDto>();
            var roledb = _unitOfWork.roleRepository.GetOne(q=>q.Id == role.Id,new List<string> { "systemmodules.submodules.systemsubmodule", "systemmodules.submodules.Rolesystempermissions.permission", "systemmodules.systemmodule" });
            if (role != null)
            {

                foreach (var item in roledb.systemmodules)
                {
                    var icon = item.systemmodule.Icon;
                    var name = item.systemmodule.Name;
                    List<SubmenuDto> submenus = new List<SubmenuDto>();
                    foreach (var submenu in item.submodules)
                    {
                        var sbicon = submenu.systemsubmodule.Icon;
                        var sbname = submenu.systemsubmodule.Name;
                        var sburl = submenu.systemsubmodule.Url;
                        List<PermissionDto> permissions = new List<PermissionDto>();

                        foreach (var perm in submenu.Rolesystempermissions)
                        {
                            var pname = perm.permission.Name;
                            permissions.Add(new PermissionDto { Name = pname });
                        }
                        submenus.Add(new SubmenuDto { Icon = sbicon, Name = sbname, Url = sburl, permissions = permissions });
                    }
                    mainmenus.Add(new MainmenuDto { Icon = icon, Name = name, submenues = submenus });
                }

            }

            return mainmenus;
        }

        public async Task<User> GetCurrentUser()
        {
            var name = _httpContext.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            return user;
        }

        public async Task<IList<MainmenuDto>> GetMainMenu(string role)
        {
            var name = _httpContext.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            var checkrole = await _userManager.IsInRoleAsync(user, role);
            IList<MainmenuDto> mainmenuDto = new List<MainmenuDto>();
            if (checkrole)
            {
                var dbrole = await _roleManager.FindByNameAsync(role);
                if (dbrole != null)
                {
                    var myrole =  await _unitOfWork.roleRepository.GetSystemModule(dbrole.Id);
                    mainmenuDto = GenerateMainmenu(myrole);
                }
            }

            return mainmenuDto;
        }

        public async Task<ProfileReponse> GetProfileAsync()
        {
            var name = _httpContext.HttpContext.User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            ProfileReponse profileReponse = new ProfileReponse();
            if (user != null)
            {

                var roles = await _userManager.GetRolesAsync(user);

                profileReponse = await FormateProfile(user, roles);

            }

            return profileReponse;
        }

        public async Task<LoginResponse> Login(AdminAuthDto dto)
        {
            LoginResponse response = new LoginResponse();
            var user = await _userManager.FindByNameAsync(dto.Email);
            if (user != null && user.Status != "ACTIVE")
            {
                response.status = false;
                response.message = $"Access denied your account is : {user.Status}";
            }
            else if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.PrimarySid,user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

                };

                foreach (var role in userRoles)
                {
                   // var dbrole = await _roleManager.FindByNameAsync(role);
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                  //  var roleclaims = await _roleManager.GetClaimsAsync(dbrole);
                    var permissions = await _helper.GetPermissions(role);
                    
                    foreach (var permission in permissions)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, permission));
                    }


                }
                var token = _helper.GetToken(authClaims);
                var refreshtoken = _helper.GetRefreshToken();
                var tokenInfo = await _unitOfWork.tokenInfoRepository.GetByUsernameAsync(dto.Email);
                if (tokenInfo != null)
                {
                    _unitOfWork.tokenInfoRepository.Remove(tokenInfo);
                    await _unitOfWork.Save();
                }

                var info = new TokenInfo { Username = user.UserName, RefreshToken = refreshtoken, RefreshTokenExpiry = DateTime.UtcNow.AddDays(7) };
                _unitOfWork.tokenInfoRepository.Add(info);
                await _unitOfWork.Save();
                try
                {

                    response = new LoginResponse
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.UserName,
                        Token = token.Token,
                        RefreshToken = refreshtoken,
                        Expiration = token.ValidTo,
                        status = true,
                        message = "Successfully logged in"
                    };

                }
                catch (Exception ex)
                {

                    response.status = false;
                    response.message = ex.Message;
                }
            }
            else
            {
                response.status = false;
                response.message = "Invalid Username or passowrd";

            }

            return response;
        }
    }
}
