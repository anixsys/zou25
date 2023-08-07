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
    public class DocumentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public DocumentController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.documentRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="DOC.CREATE")]
        public async Task<IActionResult> Create([FromBody] DocumentDto dto)
        {
            var document = _mapper.Map<Document>(dto);
            _unitOfWork.documentRepository.Add(document);
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
        [Authorize(Roles = "DOC.UPDATE")]
        public async Task<IActionResult> Update([FromBody] DocumentDto dto)
        {
            var document = _mapper.Map<Document>(dto);

            _unitOfWork.documentRepository.Update(document);
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
        [Authorize(Roles = "DOC.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.documentRepository.GetOne(q => q.Id == id);
            if (check == null)
            {
                _response.Status = false;
                _response.Message = " Record does not exist in database";
            }
            else
            {

                _unitOfWork.documentRepository.Remove(check);
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
