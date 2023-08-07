using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDepartmentController : ControllerBase
    {
        public readonly IUnitOfWork _unitofwork;
        public readonly ResponseDto _response;
        public UserDepartmentController(IUnitOfWork unitOfWork, ResponseDto reponse)
        {
            _unitofwork = unitOfWork;
            _response = reponse;
        }

        [HttpPost]
        [Authorize(Roles = "USERS.CREATE")]
        public async Task<IActionResult> Manage([FromBody] UserDepartmentRequestDto dto)
        {
            var departments = JsonConvert.DeserializeObject<IList<string>>(dto.departments);

            if (departments.Count() > 0)
            {
                var records = _unitofwork.userDepartmentRepository.Find(q => q.UserId == dto.userId);
                Task.CompletedTask.Wait();
                _unitofwork.userDepartmentRepository.BulkDelete(records.ToList());
                Task.CompletedTask.Wait();

                List<UserDepartment> userdepartments = new List<UserDepartment>();

                foreach (var item in departments)
                {
                    userdepartments.Add(new UserDepartment { UserId = dto.userId, DepartmentId = int.Parse(item) });
                }

                _unitofwork.userDepartmentRepository.BulkInsert(userdepartments);
                Task.CompletedTask.Wait();
                _response.Status = true;
                _response.Message = "User Departments successfully update";

            }
            else
            {
                _response.Status = false;
                _response.Message = " Please select campus";
            }
            return Ok(_response);
        }
    }
}
