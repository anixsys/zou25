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
    public class GeneralregulationregistrationruleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public GeneralregulationregistrationruleController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<ActionResult> create([FromBody] GeneralrgulationregistrationRequestDto dto)
        {
            var generalregulationregistrationrule = _mapper.Map<Generalregulationregistrationrule>(dto);
            _unitOfWork.generalregulationregistrationruleRepository.Add(generalregulationregistrationrule);
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

            return Ok(_response);
        }

        [HttpPut]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<ActionResult> update([FromBody] GeneralrgulationregistrationRequestDto dto)
        {
            var generalregulationregistrationrule = _mapper.Map<Generalregulationregistrationrule>(dto);
            _unitOfWork.generalregulationregistrationruleRepository.Update(generalregulationregistrationrule);
            var response = await _unitOfWork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully Update";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Record creation failed";
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<ActionResult> Delete(int id)
        {

            var generalregulationregistrationrule = _unitOfWork.generalregulationregistrationruleRepository.GetOne(q => q.Id == id);
            _unitOfWork.generalregulationregistrationruleRepository.Update(generalregulationregistrationrule);
            var response = await _unitOfWork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully Deleted";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Record creation failed";
            }
            return Ok(_response);
        }
    }
}
