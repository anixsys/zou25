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
    public class AttendenceTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public AttendenceTypeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.attendenceTypeRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="ATY.CREATE")]
        public async Task<IActionResult> Create([FromBody] AttendenceTypeRequestDto dto)
        {
            var attendenceType = _mapper.Map<AttendenceType>(dto);
            var check = _unitOfWork.attendenceTypeRepository.Find(q => q.Name == attendenceType.Name).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record already in database";

            }
            else
            {
                _unitOfWork.attendenceTypeRepository.Add(attendenceType);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully added";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Record creation failed";
                }
            }
            return Ok(_response);
        }
        [HttpPut]
        [Authorize(Roles = "ATY.UPDATE")]
        public async Task<IActionResult> Update([FromBody] AttendenceTypeRequestDto dto)
        {
            var attendenceType = _mapper.Map<AttendenceType>(dto);
            _unitOfWork.attendenceTypeRepository.Update(attendenceType);
            var response = await _unitOfWork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully Updated";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Record modification failed";
            }

          
            return Ok(_response);

        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "ATY.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {

            var attendenceType = _unitOfWork.attendenceTypeRepository.GetOne(q => q.Id == id);
            if (attendenceType != null)
            {
                _unitOfWork.attendenceTypeRepository.Remove(attendenceType);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                   
                    _response.Status = true;
                    _response.Message = "Record successfully Deleted";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Record deletion failed";
                }
            }
            else
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            return Ok(_response);
        }
    }
}
