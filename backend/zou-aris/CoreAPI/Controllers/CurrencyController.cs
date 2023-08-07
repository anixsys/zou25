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
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public CurrencyController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.currencyRepository.FindAll().ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="CUR.CREATE")]
        public async Task<IActionResult> Create([FromBody] CurrencyDto dto)
        {
            var currency = _mapper.Map<Currency>(dto);
            var check = _unitOfWork.currencyRepository.Find(q => q.Name == currency.Name).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Name already in database";

            }
            _unitOfWork.currencyRepository.Add(currency);
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
        [Authorize(Roles = "CUR.UPDATE")]
        public async Task<IActionResult> Update([FromBody] CurrencyDto dto)
        {
            var currency = _mapper.Map<Currency>(dto);
            var check = _unitOfWork.currencyRepository.GetOne(q => q.Id == currency.Id, new List<string>() { "AdmissionFees" });
            _unitOfWork.currencyRepository.Update(currency);
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

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "CUR.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var currency = _unitOfWork.currencyRepository.GetOne(q => q.Id == id, new List<string>() { "AdmissionFees" });
            if (currency == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";

            }
            if (currency.AdmissionFees.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Currency is referenced it cannot be deleted";
            }
            else
            {
                _unitOfWork.currencyRepository.Remove(currency);
                var result = await _unitOfWork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record succesfully  removed";
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
