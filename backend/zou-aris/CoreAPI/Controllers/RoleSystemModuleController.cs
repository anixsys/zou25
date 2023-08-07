using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CoreAPI.Dto;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleSystemModuleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ResponseDto _response;

        public RoleSystemModuleController(IUnitOfWork unitOfWork, IMapper mapper,ResponseDto response)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _response = response;
        }

        [HttpPost]
        [Authorize(Roles = "RSM.ASSIGN")]
        public async Task<ActionResult> Create([FromBody] RoleSystemmoduleRequestDto dto)
        {

            var check = _unitOfWork.roleSystemmoduleRepository.GetOne(q=>q.RoleId==dto.RoleId && q.SystemModuleId==dto.SystemModuleId);
            if (dto.action == "ASSIGN")
            {
                if (check != null)
                {
                    _response.Status = false;
                    _response.Message = "Module already assigned to role";
                }
                else
                {
                    RoleSystemmodule roleSystemmodule = new RoleSystemmodule();
                    roleSystemmodule.RoleId = dto.RoleId;
                    roleSystemmodule.SystemModuleId = dto.SystemModuleId;
                    _unitOfWork.roleSystemmoduleRepository.Add(roleSystemmodule);
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
                    _response.Message = "Module not assigned to role";
                }
                else
                {
                    _unitOfWork.roleSystemmoduleRepository.Remove(check);
                    _response.Status = true;
                    _response.Message = "Module successfully unassigned from role";
                }
            }
            return Ok(_response);
        }

        

    }
}
