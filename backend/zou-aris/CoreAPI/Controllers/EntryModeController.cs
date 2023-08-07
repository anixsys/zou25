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
    public class EntryModeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public EntryModeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modes = _unitOfWork.entryModeRepository.FindAll(new List<string>() { "requirements"});
            return Ok(modes);
        }

        [HttpPost]
        [Authorize(Roles ="ENM.CREATE")]
        public async Task<IActionResult> Create([FromBody] EntryModeRequestDto dto)
        {
            
            var mode = _mapper.Map<EntryMode>(dto);

            var check =  _unitOfWork.entryModeRepository.GetOne(q=>q.Name==dto.Name);
            if(check != null)
            {
                _response.Status = false;
                _response.Message = "Entry Mode already exist";
            }
            else
            {
                _unitOfWork.entryModeRepository.Add(mode);
               var response =  await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Entry Mode successfully created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occurred";
                }
            }
            return Ok(_response);
        }

        [HttpPut]
        [Authorize(Roles = "ENM.UPDATE")]
        public async Task<IActionResult> Update([FromBody] EntryModeRequestDto dto)
        {
           

            var mode = _unitOfWork.entryModeRepository.GetOne(q => q.Id == dto.Id);
            if (mode == null)
            {
                _response.Status = false;
                _response.Message = "Entry Mode not found";
            }
            else
            {
                mode.Name=dto.Name;
                _unitOfWork.entryModeRepository.Update(mode);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Entry Mode successfully updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occurred";
                }
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ENM.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {


            var mode = _unitOfWork.entryModeRepository.GetOne(q => q.Id == id);
            if (mode == null)
            {
                _response.Status = false;
                _response.Message = "Entry Mode not found";
            }
            else
            {
         
                _unitOfWork.entryModeRepository.Remove(mode);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Entry mode successfully deleted";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occurred";
                }
            }
            return Ok(_response);
        }

    }
}
