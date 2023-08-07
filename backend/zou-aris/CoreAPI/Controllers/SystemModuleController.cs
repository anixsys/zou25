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
    public class SystemModuleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public SystemModuleController(IUnitOfWork unitOfWork, IMapper mapper, ResponseDto responseDto)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = responseDto;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.systemModuleRepository.FindAll().ToList();                                                                      
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "SM.CREATE")]
        public async Task<ActionResult> Create([FromBody] SystemModuleRequestDto dto)
        {
            var systemModule = _mapper.Map<Systemmodule>(dto);
            var checkara = _unitOfWork.systemModuleRepository.Find(q => q.Name == systemModule.Name).ToList();
            if (checkara.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Name already in database";

            }
            else
            {
                _unitOfWork.systemModuleRepository.Add(systemModule);
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
        [Authorize(Roles = "SM.UPDATE")]
        public async Task<ActionResult> Update([FromBody] SystemModuleRequestDto dto)
        {
            var systemModule = _mapper.Map<Systemmodule>(dto);
            var checkara =  _unitOfWork.systemModuleRepository.GetOne(q=>q.Name==systemModule.Name);
            if (checkara != null)
            {
                _response.Status = false;
                _response.Message = "Name already in database";

            }
            else
            {
                _unitOfWork.systemModuleRepository.Update(systemModule);
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
        [Authorize(Roles = "SM.DELETE")]
        public async Task<ActionResult> Delete(int id)
        {
            var area = _unitOfWork.systemModuleRepository.GetOne(q => q.Id == id, new List<string>() { "submodules" });
            if (area == null || area.submodules.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
                _unitOfWork.systemModuleRepository.Remove(area);
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
