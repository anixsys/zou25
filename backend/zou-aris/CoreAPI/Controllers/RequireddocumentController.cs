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
    public class RequireddocumentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public RequireddocumentController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.admissionDocumentRepository.FindAll(new List<string>() { "document", "programmeType", "applicanttype" }).ToList();
            return Ok(response);
        }

        [HttpPost]
       [Authorize(Roles = "REQDOC.CREATE")]
        public async Task<IActionResult> Create([FromBody] AdmissionDocumentDto dto)
        {
            var admissiondocument = _mapper.Map<AdmissionDocument>(dto);
            _unitOfWork.admissionDocumentRepository.Add(admissiondocument);
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
        [Authorize(Roles = "REQDOC.UPDATE")]
        public async Task<IActionResult> Update([FromBody] AdmissionDocumentDto dto)
        {
            var admissiondocument = _mapper.Map<AdmissionDocument>(dto);
            _unitOfWork.admissionDocumentRepository.Update(admissiondocument);
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
        [Authorize(Roles = "REQDOC.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.admissionDocumentRepository.GetOne(q => q.id == id);
            if (check == null)
            {
                _response.Status = false;
                _response.Message = " Record does not exist in database";
            }
            else
            {

                _unitOfWork.admissionDocumentRepository.Remove(check);
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
