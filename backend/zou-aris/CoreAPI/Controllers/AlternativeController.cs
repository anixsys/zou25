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
    public class AlternativeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AlternativeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AlternativeDto dto)
        {
            var alternative = _mapper.Map<Alternative>(dto);
            var check = _unitofwork.alternativeRepository.GetOne(q => q.CourseId == alternative.CourseId && q.AcademicregulationparameterId == alternative.AcademicregulationparameterId);
            if (check != null)
            {
                _response.Status = false;
                _response.Message = "Record already exist";
            }
            else
            {
                _unitofwork.alternativeRepository.Add(alternative);
                var result = await _unitofwork.Save();
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
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var alternative = _unitofwork.alternativeRepository.GetOne(q => q.Id == id);
            _unitofwork.alternativeRepository.Remove(alternative);
            var result = await _unitofwork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record succesfully deleted";
                // _producer.SendingMessage(campus, "CREATECAMPUS");
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has ocurred";
            }
            return Ok(_response);
        }
    }
}
