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
    public class ProgrammeHistoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public ProgrammeHistoryController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<IActionResult> Create([FromBody] ProgrammeHistoryDto dto)
        {
            var history = _mapper.Map<ProgrammeHistory>(dto);

            var check = _unitOfWork.programmehistoryRepository.GetOne(q => q.Code == history.Code);
            if (check == null)
            {
                _unitOfWork.programmehistoryRepository.Add(history);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "History successfully created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "History not created";
                }
            }

            return Ok(_response);


        }

        [HttpPut]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<IActionResult> Update([FromBody] ProgrammeHistoryDto dto)
        {
            var history = _mapper.Map<ProgrammeHistory>(dto);

            var check = _unitOfWork.programmehistoryRepository.GetOne(q => q.Id == history.Id);
            if (check != null)
            {
                _unitOfWork.programmehistoryRepository.Update(history);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Programme History successfully Updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Programme History not Updated";
                }
            }

            return Ok(_response);


        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "PROG.CREATE")]
        public async Task<IActionResult> Delete(int id)
        {


            var check = _unitOfWork.programmehistoryRepository.GetOne(q => q.Id == id);
            if (check != null)
            {
                _unitOfWork.programmehistoryRepository.Remove(check);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Programme History successfully Removed";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Programme History not Updated";
                }
            }

            return Ok(_response);


        }
    }
}
