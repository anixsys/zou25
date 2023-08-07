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
    public class ProvinceController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        public ProvinceController(IUnitOfWork unitOfWork, IMapper mapper, ResponseDto responseDto)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
            _responseDto = responseDto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _unitofwork.provinceRepository.FindAll();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="PROV.CREATE")]
        public async Task<IActionResult> Create([FromBody] ProvinceDto dto)
        {
            var province= _mapper.Map<Province>(dto);
            var check = _unitofwork.provinceRepository.GetOne(q => q.Name == province.Name);
            if (check != null)
            {
                _responseDto.Status = false;
                _responseDto.Message = "Record name already taken";
            }
            else
            {
                _unitofwork.provinceRepository.Add(province);
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
        [Authorize(Roles ="PROV.UPDATE")]
        public async Task<IActionResult> Update([FromBody] ProvinceDto dto)
        {
            var province = _mapper.Map<Province>(dto);

            _unitofwork.provinceRepository.Update(province);
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
        [Authorize(Roles = "PROV.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var province = _unitofwork.provinceRepository.GetOne(q => q.Id == id);
            _unitofwork.provinceRepository.Remove(province);
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
