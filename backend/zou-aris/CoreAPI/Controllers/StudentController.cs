using CoreAPI.Dto;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ResponseDto _response;
        public StudentController(IUnitOfWork unitofwork,ResponseDto response)
        {
            _unitOfWork = unitofwork;
            _response = response;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = _unitOfWork.studentRepository.FindAll();
            return Ok(students);
        }

        [HttpGet("PendingPush")]
        public async Task<IActionResult> GetPendingPush()
        {
            var students = _unitOfWork.studentRepository.Find(q => q.Pushed == "N");
            return Ok(students);
        }

        [HttpGet("Profile/{Pin}")]
        public async Task<IActionResult> GetProfile(string Pin)
        {
            var student = _unitOfWork.studentRepository.GetOne(q => q.Pin == Pin);
            return Ok(student);
        }

        [HttpPost("Pushed")]
        public async Task<IActionResult> Pushed([FromBody] PushedDto dto)
        {
            var student = _unitOfWork.studentRepository.GetOne(q=>q.Pin==dto.Pin);
            student.Pushed = "Y";
            return Ok(student);
        }

        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] SearchDto dto)
        {
            var students = await _unitOfWork.studentRepository.Search(dto.Needle);
            return Ok(students);
        }



    }
}
