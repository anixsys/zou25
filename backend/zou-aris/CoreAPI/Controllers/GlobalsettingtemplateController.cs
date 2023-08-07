using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalsettingtemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public GlobalsettingtemplateController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.globalsettingtemplateRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "GBS.CREATE")]
        public async Task<IActionResult> Create([FromBody] GlobalsettingRequestDto dto)
        {
            var globalsettingtemplate = _mapper.Map<Globalsettingtemplate>(dto);
            _unitOfWork.globalsettingtemplateRepository.Add(globalsettingtemplate);
            var result = await _unitOfWork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record succesfully created";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has ocurred";
            }
            return Ok(_response);
        }
        [HttpPut]
        [Authorize(Roles = "GBS.UPDATE")]
        public async Task<IActionResult> Update([FromBody] GlobalsettingRequestDto dto)
        {
            var globalsettingtemplate = _mapper.Map<Globalsettingtemplate>(dto);
            _unitOfWork.globalsettingtemplateRepository.Update(globalsettingtemplate);
            var result = await _unitOfWork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record succesfully created";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has ocurred";
            }

            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "GBS.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {

            var setting = _unitOfWork.globalsettingtemplateRepository.GetOne(q => q.Id == id, new List<string>() { "generalregulations" });
            if (setting == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";

            }
            if (setting.generalregulations.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record referencing it cannot be deleted";
            }
            else
            {
                _unitOfWork.globalsettingtemplateRepository.Remove(setting);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record succesfully  removed";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has ocurred";
                }
            }

            return Ok(_response);
        }
    }
}
