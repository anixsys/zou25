using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CoreAPI.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ResponseDto _response;
        private readonly IAuthService _authService;
        public SemesterController(IUnitOfWork unitOfWork,ResponseDto response,IAuthService authService)
        {
            _response = response;
            _unitofwork = unitOfWork;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responses = _unitofwork.semesterRepository.FindAll();
            return Ok(responses);
        }

        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetRecord(string uuid)
        {
            var record = _unitofwork.semesterRepository.GetOne(q=>q.Uuid == uuid , new List<string> { "registrationperiods", "semesterregistrationfees", "examinationperiods" });
            return Ok(record);
        }

        [HttpPost]
        [Authorize(Roles ="SMST.CREATE")]
        public async Task<IActionResult> Create([FromBody] SemesterDto dto)
        {
            var semester = await _unitofwork.semesterRepository.GetLatest();
            if (semester != null)
            {
               var registrationperiod = semester.registrationperiods.OrderBy(q=>q.Id).LastOrDefault();
                if (registrationperiod != null)
                {
                    if (DateTime.Compare(DateTime.Now, DateTime.Parse(registrationperiod.EndDate.ToString())) <= 0)
                    {
                        _response.Status = false;
                        _response.Message = "Active Semester has been Found";
                        return Ok(_response);
                    }
                }

            }
              var user = await _authService.GetCurrentUser(); ;
            Semester newsemester = new Semester();
            newsemester.Name  = dto.Name;
            newsemester.Uuid = Guid.NewGuid().ToString();
            newsemester.Year = int.Parse(dto.Year);
            newsemester.Status = "PENDING";
            newsemester.InitiatedBy = user.Id;
            _unitofwork.semesterRepository.Add(newsemester);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Semester successfully created";
            }

            return Ok(_response);
        }


        [HttpPut]
        [Authorize(Roles = "SMST.UPDATE")]
        public async Task<IActionResult> Update([FromBody] SemesterDto dto)
        {
            
            
            Semester newsemester = _unitofwork.semesterRepository.GetOne(q=>q.Id == dto.Id);
            if (newsemester.Status != "PENDING")
            {
                _response.Status = false;
                _response.Message = "Semester cannot be modified";
            }
            else
            {
                var user = await _authService.GetCurrentUser();
                newsemester.Name = dto.Name;
                newsemester.Year = int.Parse(dto.Year);
                newsemester.Status = "PENDING";
                newsemester.InitiatedBy= user.Id;
                _unitofwork.semesterRepository.Update(newsemester);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Semester successfully Update";
                }
            }

            return Ok(_response);
        }

        [HttpDelete("{uuid}")]
        [Authorize(Roles = "SMST.DELETE")]
        public async Task<IActionResult> Delete(string uuid)
        {


            Semester newsemester = _unitofwork.semesterRepository.GetOne(q => q.Uuid == uuid);
            if (newsemester.Status != "PENDING")
            {
                _response.Status = false;
                _response.Message = "Semester cannot be modified";
            }
            else
            {
                
                _unitofwork.semesterRepository.Remove(newsemester);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Semester successfully Removed";
                }
            }

            return Ok(_response);
        }


    }
}
