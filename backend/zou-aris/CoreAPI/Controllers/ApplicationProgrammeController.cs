using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationProgrammeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public ApplicationProgrammeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecords(int id)
        {
            var response = _unitOfWork.applicationProgrammeRepository.Find(q => q.applicationId == id, new List<string>() { "programme", "attendenceType" }).ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "APPL.CREATE")]
        public async Task<IActionResult> Create([FromBody] ApplicationProgrammeDto dto)
        {
            var applicationProgramme = _mapper.Map<ApplicationProgramme>(dto);
            applicationProgramme.Status = "AWAITING";

            var check = _unitOfWork.applicationProgrammeRepository.Find(q => q.applicationId == applicationProgramme.applicationId && q.ProgrammeId == applicationProgramme.ProgrammeId).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Programme already added";
            }
            else
            {
                _unitOfWork.applicationProgrammeRepository.Add(applicationProgramme);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Programme successfully added to application";
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
        [Authorize(Roles = "APPL.CREATE")]
        public async Task<IActionResult> Remove(int id)
        {
            var applicationprogramme = _unitOfWork.applicationProgrammeRepository.GetOne(q => q.Id == id);
            if (applicationprogramme == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
                if (applicationprogramme.Status != "PENDING")
                {
                    _response.Status = false;
                    _response.Message = "Record cannot be deleted";
                }
                else
                {
                    _unitOfWork.applicationProgrammeRepository.Remove(applicationprogramme);
                    var result = await _unitOfWork.Save();
                    if (result > 0)
                    {
                        _response.Status = true;
                        _response.Message = "Programme successfully removed";
                    }
                }
            }

            return Ok(_response);
        }
    }
}
