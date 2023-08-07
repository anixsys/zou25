using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public ApplicantController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Applicant>>> GetAll()
        {
            var list = _unitofwork.applicantRepository.FindAll().ToList();
            return Ok(list);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Applicant>> GetProfile(int id)
        {
            var profile = _unitofwork.applicantRepository.GetOne(q => q.Id == id, new List<string>() { "applications.applicanttype", "applications.attendenceType", "applications.Campus", "applications.programmeType", "applications.admissionSession", "applications.applicationprogrammes.programme", "documents.admissionDocument.document", "subjects.subject", "otherqualifications", "workexperiences" });

            return Ok(profile);
        }

        [HttpPost]
        [Authorize(Roles ="APP.CREATE")]
        public async Task<ActionResult> Create([FromBody] ApplicantDto dto)
        {
            
            var applicant = _mapper.Map<Applicant>(dto);
            applicant.identification = Regex.Replace(applicant.identification, @"[^0-9a-zA-Z\._]", "").ToUpper();
            applicant.uuid = Guid.NewGuid().ToString();
            var check = _unitofwork.applicantRepository.Find(q => q.identification.ToLower() == applicant.identification.ToLower()).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "NationalID  Already in database";
            }
            else
            {
                _unitofwork.applicantRepository.Add(applicant);
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

       

        [HttpPost("Search")]
        public async Task<ActionResult<List<Applicant>>> Search([FromBody] SearchDto dto)
        {
            var needle = Regex.Replace(dto.Needle, @"[^0-9a-zA-Z\._]", "").ToLower();
           var results= _unitofwork.applicantRepository.Find(q => q.identification.ToLower() == needle, new List<string>() { "applications.applicanttype", "applications.attendenceType", "applications.Campus", "applications.programmeType", "applications.admissionSession", "applications.applicationprogrammes.programme", "documents.admissionDocument.document", "subjects", "otherqualifications", "workexperiences" }).ToList();

            return Ok(results);
        }

        [HttpPut]
        [Authorize(Roles = "APP.UPDATE")]
        public async Task<ActionResult> Update([FromBody] ApplicantDto dto)
        {
            var applicant = _mapper.Map<Applicant>(dto);
            applicant.identification = Regex.Replace(applicant.identification, @"[^0-9a-zA-Z\._]", "").ToUpper();
            _unitofwork.applicantRepository.Update(applicant);
            var result = await _unitofwork.Save();
            if (result > 0)
            {
               
                _response.Status = true;
                _response.Message = "Record succesfully Updated";
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
