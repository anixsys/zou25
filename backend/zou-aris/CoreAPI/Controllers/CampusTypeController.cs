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
    public class CampusTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        public CampusTypeController(IUnitOfWork unitOfWork, IMapper mapper, ResponseDto responseDto)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
            _responseDto = responseDto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _unitofwork.campusTypeRepository.FindAll();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="CTYPE.CREATE")]
        public async Task<IActionResult> Create([FromBody] CampusTypeDto dto)
        {
            var campustype = _mapper.Map<CampusType>(dto);
            var check = _unitofwork.campusTypeRepository.GetOne(q => q.Name == campustype.Name);
            if (check != null)
            {
                _responseDto.Status = false;
                _responseDto.Message = "Record name already taken";
            }
            else
            {
                _unitofwork.campusTypeRepository.Add(campustype);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _responseDto.Status = true;
                    _responseDto.Message = "Record successfully created";
                }
                else
                {
                    _responseDto.Status = false;
                    _responseDto.Message = "An error has occured";
                }
            }

            return Ok(_responseDto);

        }

        [HttpPut]
        [Authorize(Roles = "CTYPE.UPDATE")]
        public async Task<IActionResult> Update([FromBody] CampusTypeDto dto)
        {
            var campusType= _mapper.Map<CampusType>(dto);

            _unitofwork.campusTypeRepository.Update(campusType);
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
        [Authorize(Roles = "CTYPE.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var province = _unitofwork.campusTypeRepository.GetOne(q => q.Id == id);
            _unitofwork.campusTypeRepository.Remove(province);
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

