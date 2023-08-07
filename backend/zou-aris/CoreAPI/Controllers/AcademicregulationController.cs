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
    public class AcademicregulationController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AcademicregulationController(IUnitOfWork unitOfWork, IMapper mapper,ResponseDto responseDto)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
            _response = responseDto;    
        }

        [HttpPost]
        [Authorize(Roles ="ACR_CREATE")]
        public async Task<IActionResult> Create([FromBody] AcademicregulationRequestDto dto)
        {
            var academicregulation = _mapper.Map<Academicregulation>(dto);
           _unitofwork.academicregulationRepository.Add(academicregulation);
            var result = await _unitofwork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully created";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An Error has occurred";
            }
            return Ok(_response);
        }

        [HttpPost("ChangeStatus")]
        [Authorize(Roles = "ACR_CHANGESTATUS")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusDto dto)
        {
            var academicregulation = _unitofwork.academicregulationRepository.GetOne(q=>q.Id == dto.Id);
            if (academicregulation != null)
            {
                academicregulation.IsApproved = bool.Parse(dto.Status);
                _unitofwork.academicregulationRepository.Update(academicregulation);
               var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Regulation status successfully changed";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occured";
                }
            }
            else
            {
                _response.Status = false;
                _response.Message = "Regulation not found";
            }

            return Ok(_response);
        }

        [HttpGet("{programmeid}")]
        public async Task<IActionResult> GetByProgramme(int programmeid)
        {

            var response =  _unitofwork.academicregulationRepository.Find(q => q.ProgrammeId == programmeid, new List<string>() { "Attendencetype", "ProgrammeType" }).ToList();

            return Ok(response);
        }

        [HttpGet("record/{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var response = _unitofwork.academicregulationRepository.GetOne(q => q.Id == id, new List<string>() { "Parameters.Prerequisites" });
            return Ok(response);
        }

        [HttpGet("setdefault/{id}")]
        [Authorize(Roles ="ACR_SETDEFAULT")]
        public async Task<IActionResult> SetDefault(int id)
        {

            var academicregulation = _unitofwork.academicregulationRepository.GetOne(q => q.Id == id);
            if (academicregulation != null)
            {
                List<Academicregulation> newacademicregulations = new List<Academicregulation>();
                var records = _unitofwork.academicregulationRepository.Find(q => q.AttendencetypeId == academicregulation.AttendencetypeId && q.ProgrammeTypeId == academicregulation.ProgrammeTypeId && q.ProgrammeId == academicregulation.ProgrammeId);
                if (records.Count() > 0)
                {
                    foreach (var item in records)
                    {
                        if (item.Id != id)
                        {
                            item.IsActive = false;
                        }
                        else
                        {
                            item.IsActive = true;
                        }


                        newacademicregulations.Add(item);
                    }
                    _unitofwork.academicregulationRepository.BulkUpdate(newacademicregulations);
                    _response.Status = true;
                    _response.Message = "Regulation successfully set as  default";
                }

             
            }
            else
            {
                _response.Status = false;
                _response.Message = "regulation not found";
            }
            return Ok(_response);
        }





        [HttpPut]
        [Authorize(Roles = "ACR_UPDATE")]
        public async Task<IActionResult> Update([FromBody] AcademicregulationRequestDto dto)
        {
            var academicregulation = _mapper.Map<Academicregulation>(dto);
            _unitofwork.academicregulationRepository.Update(academicregulation);
            var result = await _unitofwork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully updated";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An Error has occurred";
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ACR_UPDATE")]
        public async Task<IActionResult> Delete(int id)
        {
           var record =  _unitofwork.academicregulationRepository.GetOne(q=>q.Id==id);

            if (record == null)
            {
                _response.Status = false;
                _response.Message = "An Error has occurred";
            }
            else
            {

                var response = await _unitofwork.Save();
                _response.Status = true;
                _response.Message = "Record successfully updated";
            }
            return Ok(_response);
        }
    }
}
