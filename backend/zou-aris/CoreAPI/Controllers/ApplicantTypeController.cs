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
    public class ApplicantTypeController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IHttpContextAccessor _context;
        public ApplicantTypeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper, IHttpContextAccessor context)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.applicantTypeRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="APTY.CREATE")]
        public async Task<IActionResult> Create([FromBody] ApplicantTypeDto dto)
        {
            var applicanttype = _mapper.Map<Applicanttype>(dto);
            var check = _unitOfWork.applicantTypeRepository.Find(q => q.Name.ToLower() == applicanttype.Name.ToLower()).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = " Programme Already in database";
            }
            else
            {
                _unitOfWork.applicantTypeRepository.Add(applicanttype);
                var result = await _unitOfWork.Save();
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
        [HttpPut]
        [Authorize(Roles = "APTY.UPDATE")]
        public async Task<IActionResult> Update([FromBody] ApplicantTypeDto dto)
        {
            var applicanttype = _mapper.Map<Applicanttype>(dto);

            _unitOfWork.applicantTypeRepository.Update(applicanttype);
            var result = await _unitOfWork.Save();
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
        [Authorize(Roles = "APTY.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.applicantTypeRepository.GetOne(q => q.Id == id, new List<string>() { "admissionfees" });
            if (check == null)
            {
                _response.Status = false;
                _response.Message = " Programme doest not exist in database";
            }
            else
            {
                if (check.admissionfees.Count() > 0)
                {
                    _response.Status = false;
                    _response.Message = " Programme refered in academic regulations cannot be deleted";
                }
                else
                {
                    _unitOfWork.applicantTypeRepository.Remove(check);
                    var result = await _unitOfWork.Save();
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

                }

            }
            return Ok(_response);
        }

    }
}
