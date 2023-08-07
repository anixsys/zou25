using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Administration.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantWorkExperienceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IHttpContextAccessor _context;
        public ApplicantWorkExperienceController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper, IHttpContextAccessor context)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecords(int id)
        {
            var response = _unitOfWork.applicantWorkExperienceRepository.Find(q => q.applicantId == id).ToList();        
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicantWorkExperienceDto dto)
        {
            var applicantWorkexperience = _mapper.Map<ApplicantWorkexperience>(dto);
            _unitOfWork.applicantWorkExperienceRepository.Add(applicantWorkexperience);
            var result = await _unitOfWork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully added to application";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error occured  while trying to save record";
            }
            return Ok(_response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ApplicantWorkExperienceDto dto)
        {
            var applicantWorkexperience = _mapper.Map<ApplicantWorkexperience>(dto);
            _unitOfWork.applicantWorkExperienceRepository.Update(applicantWorkexperience);
            var result = await _unitOfWork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully added to application";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error occured  while trying to save record";
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var applicantWorkexperience = _unitOfWork.applicantWorkExperienceRepository.GetOne(q => q.Id == id);
            if (applicantWorkexperience == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {

                _unitOfWork.applicantWorkExperienceRepository.Remove(applicantWorkexperience);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully removed";
                }

            }
            return Ok(_response);
        }
    }
}
