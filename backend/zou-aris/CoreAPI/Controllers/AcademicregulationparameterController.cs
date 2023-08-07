using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicregulationparameterController : ControllerBase
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AcademicregulationparameterController(IUnitOfWork unitOfWork,IMapper mapper,ResponseDto response)
        {
              _unitofwork = unitOfWork;
              _mapper=mapper;
              _response=response;
        }

        [HttpGet("{academicregulationId:int}")]
        public async Task<IActionResult> GetById(int academicregulationId)
        {
            var response =  _unitofwork.academicregulationparameterRepository.Find(q => q.AcademicRegulationId == academicregulationId, new List<string>() { "Course", "Prerequisites.course", "Alternatives.course" }).ToList();

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="ACRP_CREATE")]
        public async Task<IActionResult> Create(AcademicregulationparameterDto dto)
        {
            var academucregulationparameter = _mapper.Map<Academicregulationparameter>(dto);
             _unitofwork.academicregulationparameterRepository.Add(academucregulationparameter);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record created successfully";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has occured";
            }
            return Ok(_response);
        }


        [HttpPut]
        [Authorize(Roles = "ACRP_UPDATE")]
        public async Task<IActionResult> Update(AcademicregulationparameterDto dto)
        {
            var academucregulationparameter = _mapper.Map<Academicregulationparameter>(dto);
            _unitofwork.academicregulationparameterRepository.Update(academucregulationparameter);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record updated successfully";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has occured";
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ACRP_UPDATE")]
        public async Task<IActionResult> Delete(int id)
        {
           var academicregulationparameter=  _unitofwork.academicregulationparameterRepository.GetOne(q=>q.Id==id);
            _unitofwork.academicregulationparameterRepository.Remove(academicregulationparameter);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record deleted successfully";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has occured";
            }
            return Ok(_response);
        }





    }
}
