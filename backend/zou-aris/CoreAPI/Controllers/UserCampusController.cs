using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCampusController : ControllerBase
    {
        public readonly IUnitOfWork _unitofwork;
        public readonly ResponseDto _response;
        public UserCampusController(IUnitOfWork unitOfWork,ResponseDto reponse)
        {
            _unitofwork = unitOfWork;
            _response = reponse;
        }

        [HttpPost]
        [Authorize(Roles = "USERS.CREATE")]
        public async Task<IActionResult> Manage([FromBody] UserCampusRequestDto dto)
        {
            var campuses = JsonConvert.DeserializeObject<IList<string>>(dto.Campuses);

            if (campuses.Count() > 0)
            {
                var records = _unitofwork.userCampusRepository.Find(q=>q.UserId == dto.UserId); 
                _unitofwork.userCampusRepository.BulkDelete(records);

                List<UserCampus> administratorCampuses = new List<UserCampus>();

                foreach (var item in campuses)
                {
                    administratorCampuses.Add(new UserCampus { UserId = dto.UserId, CampusId = int.Parse(item) });
                }

                 _unitofwork.userCampusRepository.BulkInsert(administratorCampuses);
                Task.CompletedTask.Wait();
                _response.Status = true;
                _response.Message = "User Campus successfully update";

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
