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
    public class ApplicantSubjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IHttpContextAccessor _context;
        public ApplicantSubjectController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper, IHttpContextAccessor context)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecords(int id)
        {
            var response = _unitOfWork.applicantSubjectRepository.Find(q => q.applicantId == id, new List<string>() { "subject" }).ToList();
            return Ok(response);    
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecords([FromBody] ApplicantSubjectDto dto)
        {
            var applicantsubject = _mapper.Map<ApplicantSubject>(dto);
            var check = _unitOfWork.applicantSubjectRepository.Find(q => q.applicantId == applicantsubject.applicantId && q.SubjectId == applicantsubject.SubjectId && q.level == applicantsubject.level).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record already added";
            }
            else
            {
                _unitOfWork.applicantSubjectRepository.Add(applicantsubject);
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
            }

            return Ok(_response);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveRecords(int id)
        {
            var applicationsubject = _unitOfWork.applicantSubjectRepository.GetOne(q => q.Id == id);
            if (applicationsubject == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {

                _unitOfWork.applicantSubjectRepository.Remove(applicationsubject);
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
