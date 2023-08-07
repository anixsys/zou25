using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CoreAPI.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationPeriodController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ResponseDto _response;
        private readonly IAuthService _authService;

        public ExaminationPeriodController(IUnitOfWork unitOfWork,ResponseDto response,IAuthService authService)
        {
            _unitofwork = unitOfWork;
            _response = response;
            _authService = authService;
        }

        [HttpPost]
        [Authorize(Roles ="EXM.CREATE")]
        public async Task<IActionResult> Create([FromBody] ExaminationPeriodDto dto)
        {
            var user = await _authService.GetCurrentUser();
              ExaminationPeriod period = new ExaminationPeriod();   
              period.Name = dto.Name;
              period.SemesterId = dto.SemesterId;
              period.Startdate= DateTime.Parse(dto.Startdate.ToString()).ToUniversalTime();
              period.Enddate = DateTime.Parse(dto.Enddate.ToString()).ToUniversalTime();
              period.Status = "PENDING";
              period.InitiatedBy = user.Id;
              _unitofwork.examinationPeriodRepository.Add(period);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Examination period successfully created";
            }
            else
            {
                _response.Status = false;
                _response.Message = "an error has occured";
            }

            return Ok(_response);
        }


        [HttpPut]
        [Authorize(Roles = "EXM.UPDATE")]
        public async Task<IActionResult> Update([FromBody] ExaminationPeriodDto dto)
        {
            var user = await _authService.GetCurrentUser();
            ExaminationPeriod period = _unitofwork.examinationPeriodRepository.GetOne(q=>q.Id == dto.Id);
            if (period.Status != "PENDING")
            {
                _response.Status = false;
                _response.Message = "Record cannot be modified";
            }
            else
            {
                period.Name = dto.Name;
                period.SemesterId = dto.SemesterId;
                period.Startdate = DateTime.Parse(dto.Startdate.ToString()).ToUniversalTime();
                period.Enddate = DateTime.Parse(dto.Enddate.ToString()).ToUniversalTime();
                period.Status = "PENDING";
                period.InitiatedBy = user.Id;
                _unitofwork.examinationPeriodRepository.Update(period);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Examination period successfully Updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "an error has occured";
                }
            }

            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "EXM.DELETE")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _authService.GetCurrentUser();
            ExaminationPeriod period = _unitofwork.examinationPeriodRepository.GetOne(q => q.Id == id);
            if (period.Status != "PENDING")
            {
                _response.Status = false;
                _response.Message = "Record cannot be modified";
            }
            else
            {
                _unitofwork.examinationPeriodRepository.Remove(period);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Examination period successfully Removed";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "an error has occured";
                }
            }

            return Ok(_response);
        }
    }
}
