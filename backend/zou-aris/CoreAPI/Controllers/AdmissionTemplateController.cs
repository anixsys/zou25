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
    public class AdmissionTemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AdmissionTemplateController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var response = _unitofwork.admissionTemplateRepository.FindAll(new List<string>() { "programmeType" }).ToList();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var response = _unitofwork.admissionTemplateRepository.GetOne(q => q.Id == id);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="ADT.CREATE")]
        public async Task<IActionResult> Create([FromBody] AdmissionTemplateRequestDto dto)
        {
            var admissiontemplate = _mapper.Map<Admissiontemplate>(dto);
            _unitofwork.admissionTemplateRepository.Add(admissiontemplate);
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
        [Authorize(Roles = "ADT.UPDATE")]
        public async Task<IActionResult> Update([FromBody] AdmissionTemplateRequestDto dto)
        {
            var admissiontemplate = _mapper.Map<Admissiontemplate>(dto);
            _unitofwork.admissionTemplateRepository.Update(admissiontemplate);
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
        [Authorize(Roles = "ADT.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var admissiontemplate = _unitofwork.admissionTemplateRepository.GetOne(q => q.Id == id);
            _unitofwork.admissionTemplateRepository.Remove(admissiontemplate);
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

    }
}
