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

    public class AdmissionFeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AdmissionFeeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAll(int id)
        {
            var response = _unitofwork.admissionfeeRepository.Find(q => q.AdmissionFeeTemplateId == id, new List<string>() { "Applicanttype", "Currency", "programmeType" }).ToList();

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "AF.CREATE")]
        public async Task<IActionResult> Create([FromBody] AdmissionFeeDto dto)
        {
            var admissionFee = _mapper.Map<AdmissionFee>(dto);

            _unitofwork.admissionfeeRepository.Add(admissionFee);
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
        public async Task<IActionResult> Update([FromBody] AdmissionFeeDto dto)
        {
            var admissionFee = _mapper.Map<AdmissionFee>(dto);

            _unitofwork.admissionfeeRepository.Update(admissionFee);
            var result = await _unitofwork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record succesfully updated";
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

           var record =  _unitofwork.admissionfeeRepository.GetOne(q=>q.Id == id);
             _unitofwork.admissionfeeRepository.Remove(record);
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
