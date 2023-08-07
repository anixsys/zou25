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
    public class SubjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public SubjectController(IUnitOfWork unitOfWork, IMapper mapper, ResponseDto responseDto)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = responseDto;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.subjectRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
         [Authorize(Roles ="SUBJECT.CREATE")]
        public async Task<IActionResult> Create([FromBody] SubjectDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);
            _unitOfWork.subjectRepository.Add(subject);
            var result = await _unitOfWork.Save();
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
        [HttpPut]
        [Authorize(Roles = "SUBJECT.UPDATE")]
        public async Task<IActionResult> Update([FromBody] SubjectDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);

            _unitOfWork.subjectRepository.Update(subject);
            var result = await _unitOfWork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record succesfully updated";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has ocurred";
            }


            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "SUBJECT.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.subjectRepository.GetOne(q => q.id == id);
            if (check == null)
            {
                _response.Status = false;
                _response.Message = " Record does not exist in database";
            }
            else
            {

                _unitOfWork.subjectRepository.Remove(check);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    
                    _response.Status = true;
                    _response.Message = "Record succesfully deleted";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has ocurred";
                }



            }
            return Ok(_response);
        }
    }
}
