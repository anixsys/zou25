using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public FacultyController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.facultyRepository.FindAll(new List<string>() { "Departments" }).ToList();
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles ="FC.CREATE")]
        public async Task<IActionResult> Create([FromBody] FacultyRequestDto dto)
        {
            var faculty = _mapper.Map<Faculty>(dto);
            var check = _unitOfWork.facultyRepository.Find(q => q.Name.ToLower() == faculty.Name.ToLower()).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record already in database";

            }
            _unitOfWork.facultyRepository.Add(faculty);
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
        [Authorize(Roles = "FC.UPDATE")]
        public async Task<IActionResult> Update([FromBody] FacultyRequestDto dto)
        {
            var faculty = _mapper.Map<Faculty>(dto);
            _unitOfWork.facultyRepository.Update(faculty);
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

        [HttpPost("Import")]
        [Authorize(Roles = "FC.IMPORT")]
        public async Task<IActionResult> Import([FromForm] IFormFileCollection file)
        {
          
            var reader = new StreamReader(file[0].OpenReadStream());
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            List<FacultyImport> facultylist = csv.GetRecords<FacultyImport>().ToList();
            var faculties = _unitOfWork.facultyRepository.FindAll();
            var added = 0;
            if (facultylist.ToList().Count > 0)
            {

                foreach (var faculty in facultylist.ToList())
                {
                    var check = faculties.Any(q => q.Name.ToLower() == faculty.Name.ToLower());
                    if (!check)
                    {
                        var newfaculty = new Faculty { Code = faculty.Name, Name = faculty.Name, Type = faculty.Type };
                        _unitOfWork.facultyRepository.Add(newfaculty);
                        var result = await _unitOfWork.Save();
                        if (result > 0)
                        {
                           
                            _response.Status = true;
                            added++;

                        }
                        else
                        {
                            _response.Status = false;
                            _response.Message = "An error has ocurred";
                        }

                    }
                }
            }
            _response.Message = $"{added} faculties imported";
            return Ok(_response);
        }


        [HttpDelete("{id:int}")]
        [Authorize(Roles = "FC.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var faculty = _unitOfWork.facultyRepository.GetOne(q => q.Id == id, new List<string>() { "Departments" });
            if (faculty == null)
            {
                _response.Status = false;
                _response.Message = "Faculty not found";

            }
            if (faculty.Departments.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Record referencing it cannot be deleted";
            }
            else
            {
                _unitOfWork.facultyRepository.Remove(faculty);
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
