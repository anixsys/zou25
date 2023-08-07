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
    public class RegistrationFeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ResponseDto _response;
        public RegistrationFeeController(IUnitOfWork unitofwork,ResponseDto response)
        {
            _unitofwork = unitofwork;
            _response = response;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var records = _unitofwork.registrationFeeRepository.Find(q=>q.RegistrationFeeTemplateId == id, new List<string> { "currency", "faculty", "applicanttype", "programmetype" });
            return Ok(records);
        }

        [HttpPost]
        [Authorize(Roles ="RF.CREATE")]
        public async Task<IActionResult> Create([FromBody] RegistrationFeeDto dto)
        {
            var check = _unitofwork.registrationFeeRepository.GetOne(q => q.RegistrationFeeTemplateId == dto.RegistrationFeeTemplateId && q.FacultyId == dto.FacultyId && q.ApplicantTypeId == dto.ApplicantTypeId && q.ProgrammeTypeId == dto.ProgrammeTypeId);
            if (check != null)
            {
                _response.Status = false;
                _response.Message = "Parameters already added";
            }
            else
            {
                RegistrationFee registrationFee = new RegistrationFee();
                registrationFee.RegistrationFeeTemplateId = dto.RegistrationFeeTemplateId;
                registrationFee.FacultyId = dto.FacultyId;
                registrationFee.ApplicantTypeId = dto.ApplicantTypeId;
                registrationFee.ProgrammeTypeId = dto.ProgrammeTypeId;
                registrationFee.CurrencyId = dto.CurrencyId;
                registrationFee.Cost = dto.Cost;
                _unitofwork.registrationFeeRepository.Add(registrationFee);

                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Parameter successfully saved";
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
        [Authorize(Roles ="RF.UPDATE")]
        public async Task<IActionResult> Update([FromBody] RegistrationFeeDto dto)
        {
            RegistrationFee registrationFee = _unitofwork.registrationFeeRepository.GetOne(q => q.Id==dto.Id, new List<string> { "template" });

            if (registrationFee.template.Status != "PENDING")
            {
                _response.Status = false;
                _response.Message = "Template cannot be modified";
            }
            else
            {
                registrationFee.CurrencyId = dto.CurrencyId;
                registrationFee.Cost = dto.Cost;
                _unitofwork.registrationFeeRepository.Update(registrationFee);

                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Parameter successfully updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occured";
                }
            }
            
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "RF.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            RegistrationFee registrationFee = _unitofwork.registrationFeeRepository.GetOne(q => q.Id==id, new List<string> { "template"});
            if (registrationFee.template.Status != "PENDING")
            {
                _response.Status = false;
                _response.Message = "Template cannot be modified";
            }
            else
            {
                _unitofwork.registrationFeeRepository.Remove(registrationFee);

                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Parameter successfully updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occured";
                }
            }

            return Ok(_response);
        }
    }
}
