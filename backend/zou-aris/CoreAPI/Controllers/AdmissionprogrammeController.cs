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
    public class AdmissionprogrammeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AdmissionprogrammeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getAll(int id)
        {
            var response = await _unitofwork.programmeRepository.GetByAdmissionTemplate(id);
            return Ok(response);
        }

        [HttpGet("selected/{id:int}")]
        public async Task<IActionResult> getSelected(int id)
        {
            var response = _unitofwork.admissionprogrammeRepository.Find(q => q.AdmissionTemplateId == id, new List<string>() { "Programme", "attendencetypes.attendencetype" }).ToList();

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdmissionprogrammeRequestDto dto)
        {
        
          
            var selectedprogrammes = JsonConvert.DeserializeObject<List<SelectedprogrammesDto>>(dto.selectedprogrammes);
           
            var records = _unitofwork.admissionprogrammeRepository.Find(q => q.AdmissionTemplateId == dto.AdmissionTemplateId);
            if (records.Count() > 0)
            {
                _unitofwork.admissionprogrammeRepository.BulkDelete(records);
        
            }

            foreach (var item in selectedprogrammes)
            {


                var check = _unitofwork.admissionprogrammeRepository.GetOne(q => q.AdmissionTemplateId == dto.AdmissionTemplateId && q.ProgrammeId == item.id);
                if (check == null)
                {
                    Admissionprogramme programme = new Admissionprogramme();
                    programme.ProgrammeId = item.id;
                    programme.AdmissionTemplateId = dto.AdmissionTemplateId;
                    _unitofwork.admissionprogrammeRepository.Add(programme);
                    var result = await _unitofwork.Save();
                    if (result > 0)
                    {
                        await Task.CompletedTask;
                        List<Admissionattendencetype> admissionattendencetypes = new List<Admissionattendencetype>();
                        foreach (var att in item.attendencetypes)
                        {
                            admissionattendencetypes.Add(new Admissionattendencetype() { AdmissionprogrammeId = programme.Id, AttendencetypeId = int.Parse(att.Id.ToString()) });

                        }
                        _unitofwork.admissionprogrammeattendencetypeRepository.BulkInsert(admissionattendencetypes);
                      

                            _response.Status = true;
                            _response.Message = "Record succesfully created";
                      

                    }
                }

            }
            return Ok(_response);
        }

      

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Admissiontemplate = _unitofwork.admissionprogrammeRepository.GetOne(q => q.Id == id);
            _unitofwork.admissionprogrammeRepository.Remove(Admissiontemplate);
            var result = await _unitofwork.Save();
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
    }
}
