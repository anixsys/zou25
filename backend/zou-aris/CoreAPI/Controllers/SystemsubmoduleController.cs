using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreAPI.Dto;
using CoreAPI.Repositories;
using CoreAPI.Models;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemsubmoduleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public SystemsubmoduleController(IUnitOfWork unitOfWork, IMapper mapper, ResponseDto responseDto)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = responseDto;
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult> GetSubmodules(int id)
        {
            var response = _unitOfWork.systemSubmoduleRepository.Find(q=>q.SystemModuleId == id);
            return Ok(response);    
        }

        [HttpPost]
        [Authorize(Roles ="SSM.CREATE")]
        public async Task<ActionResult> Create([FromBody] SystemsubmoduleRequestDto dto)
        {

            var checkara = _unitOfWork.systemSubmoduleRepository.GetOne(q=>q.Name==dto.Name);
            if (checkara != null)
            {
                _response.Status = false;
                _response.Message = "Name already in database";

            }
            else
            {
                
                Systemsubmodule systemSubmodule = new Systemsubmodule();
                systemSubmodule.Name = dto.Name;
                systemSubmodule.SystemModuleId = dto.SystemModuleId;
                systemSubmodule.Icon = dto.Icon;
                systemSubmodule.Url = dto.Url;
                _unitOfWork.systemSubmoduleRepository.Add(systemSubmodule);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Module successfully added";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Module creation failed";
                }
            }
            return Ok(_response);

        }

        [HttpPut]
        [Authorize(Roles = "SSM.UPDATE")]
        public async Task<ActionResult> Update([FromBody] SystemsubmoduleRequestDto dto)
        {

            var checkara = _unitOfWork.systemSubmoduleRepository.GetOne(q => q.Id == dto.Id);
            if (checkara == null)
            {
                _response.Status = false;
                _response.Message = "Name already in database";

            }
            else
            {
                checkara.Name = dto.Name;
                checkara.Url = dto.Url;
                checkara.Icon = dto.Icon;
                _unitOfWork.systemSubmoduleRepository.Update(checkara);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully Updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Record modification failed";
                }
            }
          
            return Ok(_response);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SSM.DELETE")]
        public async Task<ActionResult> Delete(int id)
        {
            var area = _unitOfWork.systemSubmoduleRepository.GetOne(q => q.Id == id, new List<string>() { "permissions" });
            if (area != null && area.permissions.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
                _unitOfWork.systemSubmoduleRepository.Remove(area);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully Deleted";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Record deletion failed";
                }
            }
            return Ok(_response);    
        }
    }
}
