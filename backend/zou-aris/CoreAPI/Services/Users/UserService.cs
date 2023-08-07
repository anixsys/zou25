using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CoreAPI.Services.Users
{
    public class UserService:IUserService
    {
        public readonly UserManager<User> _usermanager;
        private readonly RoleManager<Role> _rolemanager;
        private readonly ResponseDto _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HelperFunctions _helper;


        public UserService(UserManager<User> usermanager, RoleManager<Role> rolemanager, ResponseDto response,HelperFunctions helper, IUnitOfWork unitOfWork)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _response = response;
            _helper = helper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return _unitOfWork.userRepository.FindAll(new List<string>() { "departments.department", "campuses.campus" }).ToList();
        }

        public async Task<Object> GetUserRoles(string id)
        {
            var user = _unitOfWork.userRepository.GetOne(q => q.Id == id, new List<string>() { "departments.department","campuses.campus" });
            var roles = await _usermanager.GetRolesAsync(user);
            return new { roles = roles, departments = user.departments, campuses = user.campuses };
        }

        public async Task<Object> GetAdministrator(string id)
        {
            var user = _unitOfWork.userRepository.GetOne(q => q.Id == id, new List<string>() { "departments.department", "campuses.campus" });
            var roles = _usermanager.GetRolesAsync(user);
            return new { user = user, roles = roles };
        }
        public async Task<ResponseDto> CreateUser(AdministratorRequestDto dto, string password)
        {

            var checkuser = await _usermanager.FindByNameAsync(dto.Username);
            var checkemail = await _usermanager.FindByEmailAsync(dto.Email);
            if (checkuser != null && checkemail != null)
            {
                _response.Status = false;
                _response.Message = "Username Or Email already taken";
            }
            else
            {
                /// creating a new user
                var Appuser = new User
                {
                    UserName = dto.Username,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Email = dto.Email,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    PhoneNumber = dto.phoneNumber,
                    Gender = dto.Gender,
                    Title = dto.Title,
                    Status = "ACTIVE"

                };
                var result = await _usermanager.CreateAsync(Appuser, password);

                if (result.Succeeded)
                {

                        _response.Status = true;
                        _response.Message = "Account Successfully created";
                 
                }
                else
                {
                    _response.Status = false;
                    _response.Message = result.Errors.First().Description;
                }
            }
            return _response;
        }

        public async Task<ResponseDto> UpdateUser(AdministratorRequestDto updateAdminDto)
        {
            var user = await _usermanager.FindByIdAsync(updateAdminDto.Id);

            if (user == null)
            {
                _response.Status = false;
                _response.Message = "User not found";
            }
            else
            {
                user.Name = updateAdminDto.Name;
                user.PhoneNumber = updateAdminDto.phoneNumber;
                user.Email = updateAdminDto.Email;
                user.Surname = updateAdminDto.Surname;
                user.Gender = updateAdminDto.Gender;
                user.Title = updateAdminDto.Title;
                user.Status = updateAdminDto.Status;
                var result = await _usermanager.UpdateAsync(user);
                if (result.Succeeded)
                {

                     _response.Status = true;
                    _response.Message = "Account Successfully updated";

                }

                }
                return _response;
        }

        public async Task<ResponseDto> DeleteUser(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);

            if (user == null)
            {
                _response.Status = false;
                _response.Message = "Account not found";

            }
            else
            {

                user.Status = "BLOCKED";
                await _usermanager.UpdateAsync(user);

                _response.Status = false;
                _response.Message = "Account successfully blocked";
            }

            return _response;
        }

        public async Task<ResponseDto> ChangeRole(string id, string roles)
        {
            var jsonroles = JsonConvert.DeserializeObject<IList<string>>(roles);
            var user = await _usermanager.FindByIdAsync(id);

            if (user == null)
            {
                _response.Status = false;
                _response.Message = "User not found";
            }
            else
            {
                var myroles = await _usermanager.GetRolesAsync(user);
                await _usermanager.RemoveFromRolesAsync(user, myroles);

                for (int i = 0; i < jsonroles.Count; i++)
                {
                    var rl = jsonroles[i];
                    if (await _rolemanager.RoleExistsAsync(rl))
                    {
                        var roleAction = await _usermanager.AddToRoleAsync(user, rl);
                    }
                }

                _response.Status = true;
                _response.Message = "Roles successfully updated";

            }

            return _response;
        }

        public async Task<ResponseDto> ResetPassword(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);

            if (user == null)
            {
                _response.Status = false;
                _response.Message = "Account not found";
            }
            else
            {
                var password = await _helper.GeneratePassword();
                var hashpassword = _usermanager.PasswordHasher.HashPassword(user, password);
                user.PasswordHash = hashpassword;
                user.PasswordExpiry = DateTime.Parse("2023-02-19").ToUniversalTime();
                var result = await _usermanager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    _response.Status = true;
                    _response.Message = "Password successfully reset and sent to email";
                    ///send email


                    var htmlmessage = $"<h4>Good day: {user.Name}</h4>"
                                 + "<p>Your password to access our portal has been reset.</p>"
                                 + $"<p>Username: {user.Email}</p>"
                                 + $"<p>Temporary Password: {password}</p>"
                                 + "<p>If you face any challenges using our platform please contact us on support@zou.ac.zw</p>";
                    var subject = "Password Reset";
                    var email = user.Email;
                    var emailqueue = new EmailQueue();
                    emailqueue.Email = user.Email;
                    emailqueue.Name = user.Name + " " + user.Surname;
                    emailqueue.Subject = subject;
                    emailqueue.BodyHtml = htmlmessage;
                    _unitOfWork.emailRepository.Add(emailqueue);
                    await _unitOfWork.Save();
                    // _producer.SendingMessage(emailqueue, "SENDMESSAGE");
                }
                else
                {
                    _response.Status = false;
                    _response.Message = result.Errors.First().Description;
                }



            }

            return _response;
        }

       
    }
}
