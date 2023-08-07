using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreAPI.Dto;
using CoreAPI.Models;
using Microsoft.AspNetCore.Identity;
using CoreAPI.Repositories;
using CoreAPI.Services;
using CoreAPI.Services.Users;
using System.Data;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        public readonly UserManager<User> _usermanager;
        private readonly RoleManager<Role> _rolemanager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HelperFunctions _helper;

        public UserController(IUnitOfWork unitOfWork,IUserService service, IMapper mapper, RoleManager<Role> roleManager,UserManager<User> userManager,HelperFunctions helper )
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _rolemanager = roleManager;
            _usermanager = userManager;
            _helper = helper;
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles ="USERS.VIEW")]
        public async Task<ActionResult<List<UserResponseDto>>> GetUsers()
        {
            var users = _unitOfWork.userRepository.FindAll(new List<string>() { "departments.department", "campuses.campus" }).ToList();
            var userlist = _mapper.Map<List<UserResponseDto>>(users);
            return Ok(userlist);
        }

        [HttpPost]
        [Authorize(Roles ="USERS.CREATE")]
        public async Task<ActionResult> Create([FromBody] AdministratorRequestDto dto)
        {
            var password = await _helper.GeneratePassword();
            var response = await _service.CreateUser(dto,password);
            if (response.Status)
            {
           
               
                var htmlmessage = $"<h4>Welcome : {dto.Name}</h4>"
                             + "<p>An Administration account has been created for you   please use the follow details to access your account.</p>"
                             + $"<p>Username: {dto.Email}</p>"
                             + $"<p>Temporary Password: {password}</p>"
                             + "<p>If you face any challenges using our platform please contact us on support@zou.ac.zw</p>";
                var subject = "Administrative Account";
                var email = dto.Email;
                var emailqueue = new EmailQueue();
                emailqueue.Email = dto.Email;
                emailqueue.Name = dto.Name + " " + dto.Surname;
                emailqueue.Subject = subject;
                emailqueue.BodyHtml = htmlmessage;
            }
            return Ok(response);
        }

        [HttpGet("{id}")]

        [Authorize(Roles ="USER.VIEW")]
        public async Task<ActionResult> getUser(string id)
        {
            var response = await _service.GetUserRoles(id);
            return Ok(response);
        }

        [HttpGet("resetpassword/{id}")]
        [Authorize(Roles = "PASSWORD.RESET")]
        public async Task<ActionResult> ResetPassword(string id)
        {
            var response = await _service.ResetPassword(id);           
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "USER.UPDATE")]
        public async Task<ActionResult> Update([FromBody] AdministratorRequestDto dto)
         {
            var response  = await _service.UpdateUser(dto);
            if(!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut("changeroles")]
        [Authorize(Roles = "CHANGE.ROLE")]
        public async Task<ActionResult> changerole([FromBody] ChangeRoleDto dto)
        {
            var response = await _service.ChangeRole(dto.Id, dto.roles);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "USER.DELETE")]
        public async Task<ActionResult> Delete(string id)
        {
            var response = await _service.DeleteUser(id);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
    }
}
