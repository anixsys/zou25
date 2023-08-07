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
    public class ProgrammeTypeController : ControllerBase
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public ProgrammeTypeController(IUnitOfWork unitOfWork, IMapper mapper, ResponseDto responseDto)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
            _response = responseDto;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitofwork.programmeTypeRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "PTY.CREATE")]
        public async Task<IActionResult> Create([FromBody] ProgrammeTypeDto dto)
        {
            var programmetype = _mapper.Map<ProgrammeType>(dto);
            var check = _unitofwork.programmeTypeRepository.Find(q => q.Name == programmetype.Name).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record already in database";

            }
            else
            {
                _unitofwork.programmeTypeRepository.Add(programmetype);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                   
                    _response.Status = true;
                    _response.Message = "Record successfully added";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Record creation failed";
                }
            }
            return Ok(_response);
        }
        [HttpPut]
        [Authorize(Roles = "PTY.UPDATE")]
        public async Task<IActionResult> Update([FromBody]  ProgrammeTypeDto dto)
        {
            var programmeType = _mapper.Map<ProgrammeType>(dto);
            _unitofwork.programmeTypeRepository.Update(programmeType);
            var response = await _unitofwork.Save();
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

            return Ok(_response);

        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "PTY.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var programmeType = _unitofwork.programmeTypeRepository.GetOne(q => q.Id == id);
            if (programmeType != null)
            {
                _unitofwork.programmeTypeRepository.Remove(programmeType);
                var response = await _unitofwork.Save();
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
            else
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }

            return Ok(_response);
        }
    }
}
