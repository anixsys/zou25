using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Identity;
using CoreAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<Role> _roleManager;
        private readonly ResponseDto _response;


        public RoleController(IUnitOfWork unitOfWork, IMapper mapper,RoleManager<Role> roleManager,ResponseDto response)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _response = response;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            var response = await _roleManager.Roles.ToListAsync();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(string id)
        {

            var response = await _roleManager.FindByIdAsync(id);
            return Ok(response);


        }

        [HttpGet("Systemmodule/{id}")]
        public async Task<ActionResult> GetSystemModuleById(string id)
        {
            var role = await _unitOfWork.roleRepository.GetAllSystems(id);
            return Ok(role);


        }

        [HttpPost]
        [Authorize(Roles ="ROLE.CREATE")]
        public async Task<ActionResult> Add([FromBody] RoleRequestDto roleDto)
        {
            var checkara = await _roleManager.RoleExistsAsync(roleDto.Name);
            if (checkara)
            {
                _response.Status = false;
                _response.Message = "Role name already in database";

            }
            else
            {
                try
                {
                    Role role = new Role();
                    role.Name = roleDto.Name;
                    role.View = roleDto.View;
                    var response = await _roleManager.CreateAsync(role);

                    if (response.Succeeded)
                    {
                        _response.Status = true;
                        _response.Message = "Role successfully added";
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = response.Errors.First().Description;
                    }
                }
                catch (Exception ex)
                {

                    _response.Status = false;
                    _response.Message = ex.Message;

                }

            }
            return Ok(_response);

        }

        [HttpPut]
        [Authorize(Roles = "ROLE.UPDATE")]
        public async Task<ActionResult> Update([FromBody] RoleRequestDto dto)
        {
            var record = await _roleManager.FindByIdAsync(dto.Id); ;
            record.Name = dto.Name;
            record.View = dto.View;

            var response = await _roleManager.UpdateAsync(record);
            if (response.Succeeded)
            {
                _response.Status = true;
                _response.Message = "Role successfully Updated";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Role modification failed";
            }

            
            return Ok(_response);

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ROLE.DELETE")]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                _response.Status = true;
                _response.Message = "Record successfully Deleted";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Role deletion failed";
            }
            return Ok(_response);

        }
    }
}
