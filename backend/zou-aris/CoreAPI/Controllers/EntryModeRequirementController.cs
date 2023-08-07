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
    public class EntryModeRequirementController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public EntryModeRequirementController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecords(int id)
        {
           var records =  _unitofwork.entryModeRequirementRepository.Find(q=>q.EntryModeId== id);
            return Ok(records);
        }

        [HttpPost]
        [Authorize(Roles = "ENM.CREATE")]
        public async Task<IActionResult> Create([FromBody] EntryModeRequirementRequestDto dto)
        {
            var check =  _unitofwork.entryModeRequirementRepository.GetOne(q=>q.Name==dto.Name);
            if(check != null)
            {

                _response.Status = false;
                _response.Message = "Name already exist";
            }
            else
            {
                var entryModeRequirement = _mapper.Map<EntryModeRequirement>(dto);

                _unitofwork.entryModeRequirementRepository.Add(entryModeRequirement);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Entry Mode requirement successfully created";
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
        [Authorize(Roles = "ENM.CREATE")]
        public async Task<IActionResult> Update([FromBody] EntryModeRequirementRequestDto dto)
        {
            var entryModeRequirement = _unitofwork.entryModeRequirementRepository.GetOne(q => q.Id == dto.Id);
            if (entryModeRequirement == null)
            {

                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
                entryModeRequirement.Name = dto.Name;
                entryModeRequirement.EntryModeId = dto.EntryModeId;

                _unitofwork.entryModeRequirementRepository.Update(entryModeRequirement);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Entry Mode requirement successfully updated";
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
        [Authorize(Roles = "ENM.CREATE")]
        [Authorize(Roles = "ENM.CREATE")]
        public async Task<IActionResult> Remove(int id)
        {
            var entryModeRequirement = _unitofwork.entryModeRequirementRepository.GetOne(q => q.Id == id);
            if (entryModeRequirement == null)
            {

                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {
              

                _unitofwork.entryModeRequirementRepository.Remove(entryModeRequirement);
                var response = await _unitofwork.Save();
                if (response > 0)
                {
                    
                    _response.Status = true;
                    _response.Message = "Entry Mode requirement successfully deleted";
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
