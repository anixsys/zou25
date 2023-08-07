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

    public class RegistrationFeeTemplateController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ResponseDto _response;
        public readonly IAuthService _authService;
        public RegistrationFeeTemplateController(IUnitOfWork unitofwork,ResponseDto response,IAuthService authService)
        {
            _response = response;
            _unitofwork = unitofwork;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var  records = _unitofwork.registrationFeeTemplateRepository.FindAll( new List<string> { "registrationfees" });
            return Ok(records);
        }

        [Authorize(Roles ="RFT.CREATE")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrationFeeTemplateDto dto)
        {
            RegistrationFeeTemplate registrationFeeTemplate = new RegistrationFeeTemplate();
            var user =  await _authService.GetCurrentUser();
            registrationFeeTemplate.Name = dto.Name;
            registrationFeeTemplate.Uuid = new Guid().ToString();
            registrationFeeTemplate.Year = dto.Year;
            registrationFeeTemplate.Status = "PENDING";
            registrationFeeTemplate.InitiatedBy = user.Id;

            _unitofwork.registrationFeeTemplateRepository.Add(registrationFeeTemplate);

            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully created";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has occurred";
            }

            return Ok(_response);

        }
        [Authorize(Roles = "RFT.UPDATE")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RegistrationFeeTemplateDto dto)
        {
            RegistrationFeeTemplate registrationFeeTemplate = _unitofwork.registrationFeeTemplateRepository.GetOne(q => q.Id == dto.Id);
            if (registrationFeeTemplate.Status != "PENDING")
            {
                _response.Status = false;
                _response.Message = "Record cannot be modified";
            }
            else
            {
                var user = await _authService.GetCurrentUser();
                registrationFeeTemplate.Name = dto.Name;
                registrationFeeTemplate.Year = dto.Year;
                registrationFeeTemplate.InitiatedBy = user.Id;

                _unitofwork.registrationFeeTemplateRepository.Update(registrationFeeTemplate);

                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully Update";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occurred";
                }
            }

            return Ok(_response);

        }

        [Authorize(Roles = "RFT.DELETE")]
        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(string uuid)
        {
            RegistrationFeeTemplate registrationFeeTemplate = _unitofwork.registrationFeeTemplateRepository.GetOne(q => q.Uuid == uuid);
            if (registrationFeeTemplate == null)
            {
             _response.Status= false;
                _response.Message = "Record not found";
            }
            else
            {
                if (registrationFeeTemplate.Status != "PENDING")
                {
                    _response.Status = false;
                    _response.Message = "Record cannot be modified";
                }
                else
                {

                    _unitofwork.registrationFeeTemplateRepository.Remove(registrationFeeTemplate);

                    var response = await _unitofwork.Save();
                    if (response > 0)
                    {
                        _response.Status = true;
                        _response.Message = "Record successfully Removed";
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "An error has occurred";
                    }
                }
            }

            return Ok(_response);

        }

        [Authorize(Roles = "RFT.APPROVE")]
        [HttpGet("{uuid}")]
        public async Task<IActionResult> Approve(string uuid)
        {
            RegistrationFeeTemplate registrationFeeTemplate = _unitofwork.registrationFeeTemplateRepository.GetOne(q => q.Uuid == uuid);
            if (registrationFeeTemplate == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
                if (registrationFeeTemplate.Status != "PENDING")
                {
                    _response.Status = false;
                    _response.Message = "Record cannot be modified";
                }
                else
                {
                    var user = await _authService.GetCurrentUser();
                    registrationFeeTemplate.Status = "APPROVED";
                    registrationFeeTemplate.ApprovedBy=user.Id;
                    _unitofwork.registrationFeeTemplateRepository.Update(registrationFeeTemplate);

                    var response = await _unitofwork.Save();
                    if (response > 0)
                    {
                        _response.Status = true;
                        _response.Message = "Record successfully Removed";
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "An error has occurred";
                    }
                }
            }

            return Ok(_response);

        }



    }
}
