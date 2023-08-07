using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public CourseController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _unitOfWork.courseRepository.FindAll(new List<string>() { "Department" }).ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="CS.CREATE")]
        public async Task<IActionResult> Create([FromBody] CourseRequestDto dto)
        {
            var course = _mapper.Map<Course>(dto);

            var check = _unitOfWork.courseRepository.Find(q => q.Code.ToLower() == course.Code.ToLower()).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = " Course Already in database";
            }
            else
            {
                _unitOfWork.courseRepository.Add(course);
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

            }
            return Ok(_response);
        }

        [HttpPut]
        [Authorize(Roles = "CS.UPDATE")]
        public async Task<IActionResult> Update([FromBody] CourseRequestDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            var check = _unitOfWork.courseRepository.Find(q => q.Code.ToLower() == course.Code.ToLower()).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = " Programme Already in database";
            }
            else
            {
                _unitOfWork.courseRepository.Update(course);
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

            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "CS.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.courseRepository.GetOne(q => q.Id == id, new List<string>() { "Academicregulationparameters" });
            if (check == null)
            {
                _response.Status = false;
                _response.Message = " Programme doest not exist in database";
            }
            else
            {
                if (check.Academicregulationparameters.Count() > 0)
                {
                    _response.Status = false;
                    _response.Message = " Course refered in academic regulations cannot be deleted";
                }
                else
                {
                    _unitOfWork.courseRepository.Remove(check);
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

            }
            return Ok(_response);
        }

        [HttpPost("Import")]
        [Authorize(Roles = "CS.IMPORT")]
        public async Task<IActionResult> ImportProgrammes([FromForm] IFormFileCollection file)
        {

            var reader = new StreamReader(file[0].OpenReadStream());
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            List<CourseImportDto> courseList = csv.GetRecords<CourseImportDto>().ToList();
            var courses = _unitOfWork.courseRepository.FindAll();
            var departments = _unitOfWork.departmentRepository.FindAll();
            List<Course> newcourses = new List<Course>();

            if (courseList.ToList().Count > 0)
            {

                foreach (var course in courseList.ToList())
                {
                    var departmentname = course.DepartmentName;
                    var department = departments.Where(q => q.Name.ToLower() == departmentname.ToLower()).First();
                    var checkcourse = courses.Any(q => q.Code.ToLower() == course.Code.ToLower());
                    if (!checkcourse && department != null)
                    {
                        newcourses.Add(new Course { Code = course.Code, Name = course.Name, DepartmentId = department.Id });
                    }
                }
            }



            _unitOfWork.courseRepository.BulkInsert(newcourses);
            var result = await _unitOfWork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = $"{newcourses.Count} Records succesfully created";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has ocurred";
            }
            return Ok(_response);

        }
    }
}
