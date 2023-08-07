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
    public class AdmissionfeetemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AdmissionfeetemplateController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response =  _unitofwork.admissionfeetampleRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "AF.CREATE")]
        public async Task<IActionResult> Create([FromBody] AdmissionfeetemplateDto dto)
        {
            var admissionFeeTemplate = _mapper.Map<AdmissionFeeTemplate>(dto);
            admissionFeeTemplate.Status = "PENDING";
            _unitofwork.admissionfeetampleRepository.Add(admissionFeeTemplate);
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
            return Ok(_response);
        }
        [HttpPut]
        [Authorize(Roles = "AF.UPDATE")]
        public async Task<IActionResult> Update([FromBody] AdmissionfeetemplateDto dto)
        {
            var admissionfeetemplate = _mapper.Map<AdmissionFeeTemplate>(dto);

            _unitofwork.admissionfeetampleRepository.Update(admissionfeetemplate);
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
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "AF.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = _unitofwork.admissionfeetampleRepository.GetOne(q=>q.Id == id);
            _unitofwork.admissionfeetampleRepository.Remove(record);
            var result = await _unitofwork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record succesfully deleted";
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
