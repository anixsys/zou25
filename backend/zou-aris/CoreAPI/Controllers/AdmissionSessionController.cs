using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class AdmissionSessionController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AdmissionSessionController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitofwork.admissionSessionRepository.FindAll(new List<string>() { "Admissionsessiontemplate" }).ToList();
            return Ok(response);
        }
        [HttpGet("Published")]
        public async Task<ActionResult> GetPublished()
        {
            var response = _unitofwork.admissionSessionRepository.Find(q => q.IsPublished == true).ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "ADMS.CREATE")]
        public async Task<IActionResult> Create([FromBody] AdmissionSessionDto dto)
        {
            var admissionSession = _mapper.Map<AdmissionSession>(dto);
            var selected = JsonConvert.DeserializeObject<List<string>>(dto.templates);
            _unitofwork.admissionSessionRepository.Add(admissionSession);
            var result = await _unitofwork.Save();

            if (result > 0)
            {
                List<Admissionsessiontemplate> admissionsessiontemplates = new List<Admissionsessiontemplate>();
                foreach (var item in selected)
                {
                    admissionsessiontemplates.Add(new Admissionsessiontemplate { AdmissionSessionId = admissionSession.Id, AdmissionTemplateId = int.Parse(item) });
                }

                _unitofwork.admissionsessiontemplateRepository.BulkInsert(admissionsessiontemplates);
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
        [HttpPut]
        [Authorize(Roles = "ADMS.UPDATE")]
        public async Task<IActionResult> Update([FromBody] AdmissionSessionDto dto)
        {
            var admissionSession = _mapper.Map<AdmissionSession>(dto);
            var selected = JsonConvert.DeserializeObject<List<string>>(dto.templates);
            _unitofwork.admissionSessionRepository.Update(admissionSession);
            var result = await _unitofwork.Save();
            if (result > 0)
            {
                var admissionsessiontemplate = _unitofwork.admissionsessiontemplateRepository.Find(q => q.AdmissionSessionId == admissionSession.Id).ToList();
                _unitofwork.admissionsessiontemplateRepository.BulkDelete(admissionsessiontemplate);
                await _unitofwork.Save();
                List<Admissionsessiontemplate> templates2 = new List<Admissionsessiontemplate>();
                foreach (var item in selected)
                {
                    templates2.Add(new Admissionsessiontemplate { AdmissionSessionId = admissionSession.Id, AdmissionTemplateId = int.Parse(item) });
                }

                _unitofwork.admissionsessiontemplateRepository.BulkInsert(templates2);

                    _response.Status = true;
                    _response.Message = "Record succesfully updated";
                
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has ocurred";
            }


            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ADMS.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitofwork.admissionSessionRepository.GetOne(q => q.Id == id, new List<string>() { "Admissionsessiontemplate" });
            if (check == null)
            {
                _response.Status = false;
                _response.Message = " Record does not exist in database";
            }
            else
            {

                _unitofwork.admissionSessionRepository.Remove(check);
                var result = await _unitofwork.Save();
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
            return Ok(_response);
        }
    }
}
