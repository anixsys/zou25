using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreAPI.Models;
using CoreAPI.Dto;
using CoreAPI.Repositories;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleSubmoduleController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public RoleSubmoduleController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }
        [HttpPost]
        [Authorize(Roles = "RSM.ASSIGN")]
        public async Task<ActionResult> Create([FromBody] RoleSubmoduleRequestDto dto)       
        {
            var check =  _unitOfWork.rolesystemsubmoduleRepository.GetOne(q=>q.RoleId==dto.RoleId && q.SystemSubmoduleId== dto.SystemSubmoduleId);
            if (dto.action == "ASSIGN")
            {
                if (check != null)
                {
                    _response.Status = false;
                    _response.Message = "Module already assigned to role";
                }
                else
                {
                    RoleSystemsubmodule roleSystemsubmodule = new RoleSystemsubmodule();
                    roleSystemsubmodule.RoleId = dto.RoleId;
                    roleSystemsubmodule.RoleSystemmoduleId = dto.RoleSystemmoduleId;
                    roleSystemsubmodule.SystemSubmoduleId = dto.SystemSubmoduleId;
                    _unitOfWork.rolesystemsubmoduleRepository.Add(roleSystemsubmodule);
                    var response = await _unitOfWork.Save();
                    if (response > 0)
                    {
                        _response.Status = true;
                        _response.Message = "Module successfully assigned to role";
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Module assigment failed";
                    }

                }
            }
            else
            {
                if (check == null)
                {
                    _response.Status = false;
                    _response.Message = "Sub module not found";
                }
                else
                {
                    _unitOfWork.rolesystemsubmoduleRepository.Remove(check);
                    await _unitOfWork.Save();
                    _response.Status = true;
                    _response.Message = "Module successfully unassigned to role";
                }
            }

            return Ok(_response);
        }

       
    }
}
