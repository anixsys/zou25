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
    public class GeneralregulationacademicruleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public GeneralregulationacademicruleController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<ActionResult> create([FromBody] GeneralregulationacademicruleRequestDto dto)
        {
            var generalregulationacademicrule = _mapper.Map<Generalregulationacademicrule>(dto);
            _unitOfWork.generalregulationacademicruleRepository.Add(generalregulationacademicrule);
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
        public async Task<ActionResult> update([FromBody] GeneralregulationacademicruleRequestDto dto)
        {
            var generalregulationacademicrule = _mapper.Map<Generalregulationacademicrule>(dto);
            _unitOfWork.generalregulationacademicruleRepository.Update(generalregulationacademicrule);
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

            var generalregulationregistrationrule = _unitOfWork.generalregulationacademicruleRepository.GetOne(q => q.Id == id);
            _unitOfWork.generalregulationacademicruleRepository.Remove(generalregulationregistrationrule);
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
