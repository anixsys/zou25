using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        public CampusController(IUnitOfWork unitOfWork,IMapper mapper,ResponseDto responseDto)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
            _responseDto = responseDto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _unitofwork.campusRepository.FindAll(new List<string> { "CampusType", "District" });
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="CAMP.CREATE")]
        public async Task<IActionResult> Create([FromBody] CampusDto dto)
        {
            var campus = _mapper.Map<Campus>(dto);
            var check =  _unitofwork.campusRepository.GetOne(q=>q.Name==campus.Name);
            if (check != null)
            {
                _responseDto.Status = false;
                _responseDto.Message = "Campus name already taken";
            }
            else
            {
                _unitofwork.campusRepository.Add(campus);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _responseDto.Status =true;
                    _responseDto.Message = "Record successfully created";
                }
                else
                {
                    _responseDto.Status=false;
                    _responseDto.Message = "An error has occured";
                }
            }

            return Ok(_responseDto);

        }

        [HttpPut]
        [Authorize(Roles = "CAMP.UPDATE")]
        public async Task<IActionResult> Update([FromBody] CampusDto dto)
        {
            var campus = _mapper.Map<Campus>(dto);
           
                _unitofwork.campusRepository.Update(campus);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _responseDto.Status = true;
                    _responseDto.Message = "Record successfully updated";
                }
                else
                {
                    _responseDto.Status = false;
                    _responseDto.Message = "An error has occured";
                }
            

            return Ok(_responseDto);

        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "CAMP.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var campus = _unitofwork.campusRepository.GetOne(q=>q.Id == id);
            _unitofwork.campusRepository.Remove(campus);
            var result = await _unitofwork.Save();  
            if (result > 0)
            {
                _responseDto.Status = true;
                _responseDto.Message = "Record successfully deleted";
            }
            else
            {
                _responseDto.Status = false;
                _responseDto.Message = "An error has occured";
            }


            return Ok(_responseDto);


        }

    }
}
