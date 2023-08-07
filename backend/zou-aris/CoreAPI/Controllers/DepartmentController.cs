using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreAPI.Dto;
using CoreAPI.Repositories;
using CoreAPI.Models;
using CsvHelper;
using System.Globalization;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public DepartmentController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            var response = _unitOfWork.departmentRepository.FindAll(new List<string>() { "Faculty" }).ToList();
            return Ok(response);


        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {

            var response = _unitOfWork.departmentRepository.GetOne(q => q.Id == id);
            return Ok(response);


        }

        [HttpPost]
        [Authorize(Roles ="DPT.CREATE")]
        public async Task<ActionResult> Add([FromBody] DepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            var check = _unitOfWork.departmentRepository.Find(q => q.Name == department.Name).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Department name already in database";

            }
            else
            {
                _unitOfWork.departmentRepository.Add(department);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Department successfully added";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Department creation failed";
                }
            }
            return Ok(_response);

        }
        [HttpPost("Import")]
        [Authorize(Roles = "DPT.IMPORT")]
        public async Task<IActionResult> Import([FromForm] IFormFileCollection file)
        {
            var reader = new StreamReader(file[0].OpenReadStream());
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            List<DepartmentImportDto> departmentimports = csv.GetRecords<DepartmentImportDto>().ToList();
            List<Department> departmentlist = new List<Department>();
            var departments = _unitOfWork.departmentRepository.FindAll();
            var faculties = _unitOfWork.facultyRepository.FindAll();
            var added = 0;
            if (departmentimports.ToList().Count > 0)
            {

                foreach (var dpt in departmentimports.ToList())
                {
                    var check = departments.Any(q => q.Name.ToLower() == dpt.Name.ToLower());
                    if (!check)
                    {
                        var faculty = faculties.FirstOrDefault(q => q.Name == dpt.Faculty);
                        if (faculty != null)
                        {
                            var department = new Department { FacultyId = faculty.Id, Name = dpt.Name };
                             departmentlist.Add(department);
                          
                        }

                    }
                }
            }
            if(departmentlist.Count > 0)
            {
                _unitOfWork.departmentRepository.BulkInsert(departmentlist);
                _response.Status = true;
                _response.Message = $"{departmentlist.Count} Department imported";
            }
           
            return Ok(_response);
        }


        [HttpPut]
        [Authorize(Roles = "DPT.UPDATE")]
        public async Task<ActionResult> Update([FromBody] DepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            _unitOfWork.departmentRepository.Update(department);
            var response = await _unitOfWork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Department successfully Updated";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Department modification failed";
            }

            return Ok(_response);

        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "DPT.DELETE")]
        public async Task<ActionResult> Delete(int id)
        {

            var Department = _unitOfWork.departmentRepository.GetOne(q => q.Id == id);
            if (Department != null)
            {
                _unitOfWork.departmentRepository.Remove(Department);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Department successfully Deleted";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Department deletion failed";
                }
            }
            else
            {
                _response.Status = false;
                _response.Message = "Department not found";
            }

            return Ok(_response);

        }
    }
}
