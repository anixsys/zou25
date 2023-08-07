using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public RolePermissionController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "RSM.ASSIGN")]
        public async Task<ActionResult> Create([FromBody] RolePermissionRequestDto dto)
        {
            var check = _unitOfWork.roleSystempermissionRepository.GetOne(q=>q.RoleId==dto.RoleId && q.SystempermissionId==dto.PermissionId);
             if (dto.action == "ASSIGN")
            {
                if (check != null)
                {
                    _response.Status = false;
                    _response.Message = "Record already assigned to role";
                }
                else
                {
                    RoleSystempermission rolePermission = new RoleSystempermission();
                    rolePermission.RoleId = dto.RoleId;
                    rolePermission.SystempermissionId = dto.PermissionId;
                    rolePermission.RoleSystemsubmoduleId = dto.RoleSystemSubmoduleId;
                    _unitOfWork.roleSystempermissionRepository.Add(rolePermission);
                    var response = await _unitOfWork.Save();
                    if (response > 0)
                    {
                       // var claimtype = Regex.Replace(permission.Name, @"[^0-9a-zA-Z\._]", "").ToUpper();
                       // await _roleManager.AddClaimAsync(role, new Claim(type: claimtype, permission.Name));

                        _response.Status = true;
                        _response.Message = "Record successfully assigned to role";
                    }
                    else
                    {
                        _response.Status = false;
                        _response.Message = "Record assigment failed";
                    }

                }
            }
            else
            {
                _unitOfWork.roleSystempermissionRepository.Remove(check);
                _response.Status = true;
                _response.Message = "Record successfully unassigned to role";
            }
            return Ok(_response);
        }

    }
}
