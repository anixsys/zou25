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
    public class RegistrationPeriodController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ResponseDto _response;
        private readonly IAuthService _authservice;
        public RegistrationPeriodController(IUnitOfWork unitofwork,ResponseDto response,IAuthService authservice)
        {
            _unitofwork = unitofwork;   
            _response = response;
            _authservice = authservice;
        }

        [HttpGet()]
        public async Task<IActionResult> GetRecords(string uuid)
        {
            var semester = _unitofwork.semesterRepository.GetLatest();
            return Ok(semester);
           
        }

    

        [HttpPost]
        [Authorize(Roles ="REGP.CREATE")]
        public async Task<IActionResult> Create([FromBody] RegistrationPeriodDto dto)
        {
            var semeseter = _unitofwork.semesterRepository.GetOne(q => q.Id == dto.SemesterId);
            if(semeseter == null)
            {
                _response.Status = false;
                _response.Message = "Semester not found";
            }
            else
            {
               var lastperiod  = await _unitofwork.registraationPeriodRepository.GetLastsync(semeseter.Id);
                if(lastperiod != null) {
                    if (DateTime.Compare(dto.StartDate, lastperiod.EndDate) <= 0)
                    {
                        _response.Status = false;
                        _response.Message = "Start Date Cannot be before last registration period";
                        return Ok(_response);
                    }
                }
                RegistrationPeriod registrationperiod = new RegistrationPeriod();
                registrationperiod.SemesterId = semeseter.Id;
                registrationperiod.Type =dto.Type;
                registrationperiod.StartDate = DateTime.Parse(dto.StartDate.ToString()).ToUniversalTime();
                registrationperiod.EndDate = DateTime.Parse(dto.EndDate.ToString()).ToUniversalTime();
                registrationperiod.Status = "PENDING";
                _unitofwork.registraationPeriodRepository.Add(registrationperiod);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Registration Period Successsfully Created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occured";
                }
            }
            return Ok(_response);   
        }
        [HttpPut]
        [Authorize(Roles ="REGP.UPDATE")]
        public async Task<IActionResult> Update([FromBody]RegistrationPeriodDto dto)
        {
            var registrationperiod = _unitofwork.registraationPeriodRepository.GetOne(q=>q.Id== dto.Id);
            if (registrationperiod == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
                if (registrationperiod.Status == "PENDING")
                {
                    registrationperiod.StartDate = dto.StartDate;
                    registrationperiod.EndDate = dto.EndDate;
                    registrationperiod.Type = dto.Type; 

                    _unitofwork.registraationPeriodRepository.Update(registrationperiod);
                    var response = await _unitofwork.Save();
                    if (response > 0)
                    {
                        _response.Status = true;
                        _response.Message = "Registration Period Successsfully Updated";
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "An error has occured";
                    }
                }
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "REGP.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrationperiod = _unitofwork.registraationPeriodRepository.GetOne(q => q.Id == id);
            if (registrationperiod == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
                if (registrationperiod.Status == "PENDING")
                {
                    

                    _unitofwork.registraationPeriodRepository.Remove(registrationperiod);
                    var response = await _unitofwork.Save();
                    if (response > 0)
                    {
                        _response.Status = true;
                        _response.Message = "Registration Period Successsfully delete";
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "An error has occured";
                    }
                }
            }
            return Ok(_response);
        }





    }
}
