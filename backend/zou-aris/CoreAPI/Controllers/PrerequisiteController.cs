using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrerequisiteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public PrerequisiteController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles ="PREQ.CREATE")]
        public async Task<IActionResult> Create([FromBody] PrerequisiteDto dto)
        {
            var prerequisite = _mapper.Map<Prerequisite>(dto);
            _unitOfWork.prerequisiteRepository.Add(prerequisite);
            var response = await _unitOfWork.Save();

            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully created";
                     
            }
           
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "PREQ.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = _unitOfWork.prerequisiteRepository.GetOne(q=>q.Id == id);
            if (record == null)
            {
                _response.Status=false;
                _response.Message = "Record not found";
            }
            else
            {
                _unitOfWork.prerequisiteRepository.Remove(record);
                var response = await _unitOfWork.Save();
                if(response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully removed";
                }

            }
            return Ok(_response);
        }
    }
}
