using CoreAPI.Dto;
using CoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ResponseDto _response;
        public UserRoleController(UserManager<User> userManager, ResponseDto response)
        {
            _userManager = userManager;
            _response = response;
        }

        [HttpPost]
        [Authorize(Roles = "USERS.CREATE")]
        public async Task<IActionResult> Manage([FromBody] UserRoleRequestDto dto)
        {
            var roles = JsonConvert.DeserializeObject<IList<string>>(dto.roles);
            if (roles == null || roles.Count == 0)
            {
                _response.Status = false;
                _response.Message = "Please select roles";
            }
            else
            {
                var user = await _userManager.FindByIdAsync(dto.userId);
                if (user == null)
                {
                    _response.Status = false;
                    _response.Message = "Bad Request";
                }
                else
                {
                    var dbroles = await _userManager.GetRolesAsync(user);
                    var check = await _userManager.RemoveFromRolesAsync(user, dbroles);
                    if (check.Succeeded)
                    {
                          await _userManager.AddToRolesAsync(user, roles);
                        _response.Status = true;
                        _response.Message = "Roles successfully assigned to user";
                        
                    }
                }
            }
            return Ok(_response);
        }
    }
}
