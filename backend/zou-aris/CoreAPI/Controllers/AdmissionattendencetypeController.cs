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
    public class AdmissionattendencetypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AdmissionattendencetypeController(IUnitOfWork  unitofwork,ResponseDto response,IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;   
        }

        [HttpPost]
        [Authorize(Roles ="AAT_CREATE")]
        public async Task<IActionResult> Create([FromBody] AdmissionattendencetypeRequestDto dto)
        {
            var admissionattendencetype = _mapper.Map<Admissionattendencetype>(dto);
            _unitofwork.admissionattendencetypeRepository.Add(admissionattendencetype);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = false;
                _response.Message = "Record successfully created";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has occurred";
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "AAT_DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = _unitofwork.admissionattendencetypeRepository.GetOne(q=>q.Id == id);
            _unitofwork.admissionattendencetypeRepository.Remove(record);   
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = false;
                _response.Message = "Record successfully deleted";
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
