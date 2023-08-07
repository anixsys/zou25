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
 
    public class ProgrammeSpecializationController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public ProgrammeSpecializationController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<IActionResult> Create([FromBody] ProgrammeSpecializationDto dto)
        {
              var specialization = _mapper.Map<ProgrammeSpecialization>(dto);

             var check =_unitofwork.programmeSpecializationRepository.GetOne(q=>q.Area== specialization.Area);
            if (check == null)
            {
                _unitofwork.programmeSpecializationRepository.Add(specialization);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Specialization successfully created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Specialization not created";
                }
            }
          
            return Ok(_response);


        }

        [HttpPut]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<IActionResult> Update([FromBody] ProgrammeSpecializationDto dto)
        {
            var specialization = _mapper.Map<ProgrammeSpecialization>(dto);

            var check = _unitofwork.programmeSpecializationRepository.GetOne(q => q.Id == specialization.Id);
            if (check != null)
            {
                _unitofwork.programmeSpecializationRepository.Update(specialization);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Specialization successfully Updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Specialization not Updated";
                }
            }

            return Ok(_response);


        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<IActionResult> Delete(int id)
        {
         

            var check = _unitofwork.programmeSpecializationRepository.GetOne(q => q.Id == id);
            if (check != null)
            {
                _unitofwork.programmeSpecializationRepository.Remove(check);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Specialization successfully Removed";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Specialization not Updated";
                }
            }

            return Ok(_response);


        }
    }
}
