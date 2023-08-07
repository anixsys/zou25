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
    [Authorize]
    public class ApplicantOtherQualificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IHttpContextAccessor _context;
        public ApplicantOtherQualificationController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper, IHttpContextAccessor context)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecords(int id)
        {
            var response = _unitOfWork.applicantOtherqualificationRepository.Find(q => q.applicantId == id).ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "APPO.CREATE")]
        public async Task<IActionResult> Create([FromBody] ApplicantOtherqualificationDto dto)
        {
            var applicantotherqualification = _mapper.Map<ApplicantOtherqualification>(dto);
            _unitOfWork.applicantOtherqualificationRepository.Add(applicantotherqualification);
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
        [Authorize(Policy = "APPD.UPDATE")]
        public async Task<IActionResult> Update([FromBody] ApplicantOtherqualificationDto dto)
        {
            var applicantotherqualification = _mapper.Map<ApplicantOtherqualification>(dto);
            _unitOfWork.applicantOtherqualificationRepository.Update(applicantotherqualification);
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
        [Authorize(Roles = "APPD.DELETE")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var applicantOtherqualification = _unitOfWork.applicantOtherqualificationRepository.GetOne(q => q.Id == id);
            if (applicantOtherqualification == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {

                _unitOfWork.applicantOtherqualificationRepository.Remove(applicantOtherqualification);
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
