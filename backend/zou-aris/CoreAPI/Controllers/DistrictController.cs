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
    public class DistrictController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        public DistrictController(IUnitOfWork unitOfWork, IMapper mapper, ResponseDto responseDto)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
            _responseDto = responseDto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _unitofwork.districtRepository.FindAll(new List<string> { "Province" });
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="DISTR.CREATE")]
        public async Task<IActionResult> Create([FromBody] DistrictDto dto)
        {
            var district = _mapper.Map<District>(dto);
            var check = _unitofwork.districtRepository.GetOne(q => q.Name == district.Name);
            if (check != null)
            {
                _responseDto.Status = false;
                _responseDto.Message = "Record name already taken";
            }
            else
            {
                _unitofwork.districtRepository.Add(district);
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
        [Authorize(Roles = "DISTR.UPDATE")]
        public async Task<IActionResult> Update([FromBody] DistrictDto dto)
        {
            var district = _mapper.Map<District>(dto);

            _unitofwork.districtRepository.Update(district);
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
        [Authorize(Roles = "DISTR.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var district = _unitofwork.districtRepository.GetOne(q => q.Id == id);
            _unitofwork.districtRepository.Remove(district);
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

