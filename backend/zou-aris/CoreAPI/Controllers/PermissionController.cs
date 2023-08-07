using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CoreAPI.Dto;
using CoreAPI.Repositories;
using CoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public PermissionController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAll(int id)
        {
            var response = _unitOfWork.systempermissionRepository.Find(q=>q.SystemSubmoduleId== id);    
            return Ok(response);
        }

        [HttpPost]
       // [Authorize(Roles = "PM.CREATE")]
        public async Task<ActionResult> Create([FromBody] PermissionRequestDto dto)
        {
           var permission = _mapper.Map<Systempermission>(dto);
            var check = _unitOfWork.systempermissionRepository.GetOne(q=>q.Name== permission.Name);
            if(check == null)
            {
                _unitOfWork.systempermissionRepository.Add(permission);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error has occured";
                }
            }
            return Ok(_response);

        }

        [HttpPut]
       // [Authorize(Roles = "PM.UPDATE")]

        public async Task<ActionResult> Update([FromBody] PermissionRequestDto dto)
        {

            var permission = _mapper.Map<Systempermission>(dto);
            _unitOfWork.systempermissionRepository.Update(permission);   
            var response = await _unitOfWork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Permission successfully updated";
            }
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
      //  [Authorize(Roles = "PM.DELETE")]
        public async Task<ActionResult> Delete(int id)
        {
             var permission = _unitOfWork.systempermissionRepository.GetOne(q=>q.Id==id);
            _unitOfWork.systempermissionRepository.Remove(permission);  
            var response = await _unitOfWork.Save(); 
            if (response > 0) {
                _response.Status = true;
                _response.Message = "Permission succesfully deleted";
            }

            return Ok(response);
        }

    }
}
