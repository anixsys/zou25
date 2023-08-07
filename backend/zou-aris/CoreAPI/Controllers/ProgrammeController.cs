using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public ProgrammeController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var  response = _unitOfWork.programmeRepository.FindAll(new List<string>() { "Type", "Department", "Specializations", "History" }).ToList();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = _unitOfWork.programmeRepository.GetOne(q => q.Id == id, new List<string>() { "Type", "Academicregulations.Attendencetype" });
            return Ok(response);
        }
        [HttpGet("ByType/{id:int}")]
        public async Task<IActionResult> GetByType(int id)
        {
            var response = _unitOfWork.programmeRepository.Find(q => q.ProgrammeTypeId == id).ToList();
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles ="PROG.CREATE")]
        public async Task<IActionResult> Create([FromBody] ProgrammeRequestDto dto)
        {
            var programme = _mapper.Map<Programme>(dto);
            programme.Status = "ACTIVE";
            var check = _unitOfWork.programmeRepository.Find(q => q.Code.ToLower() == programme.Code.ToLower()).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = " Programme Already in database";
            }
            else
            {
                _unitOfWork.programmeRepository.Add(programme);
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
        [Authorize(Roles ="PROG.UPDATE")]
        public async Task<IActionResult> Update([FromBody] ProgrammeRequestDto dto)
        {
            var programme = _mapper.Map<Programme>(dto);
            var check = _unitOfWork.programmeRepository.Find(q => q.Code.ToLower() == programme.Code.ToLower()).ToList();

            _unitOfWork.programmeRepository.Update(programme);
            var result = await _unitOfWork.Save();
            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record succesfully Updated";
            }
            else
            {
                _response.Status = false;
                _response.Message = "An error has ocurred";
            }

            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "PROG.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.programmeRepository.GetOne(q => q.Id == id, new List<string>() { "Academicregulations" });
            if (check == null)
            {
                _response.Status = false;
                _response.Message = " Programme doest not exist in database";
            }
            else
            {
                if (check.Academicregulations.Count() > 0)
                {
                    _response.Status = false;
                    _response.Message = " Programme refered in academic regulations cannot be deleted";
                }
                else
                {
                    _unitOfWork.programmeRepository.Remove(check);
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
        [Authorize(Roles ="PROG.IMPORT")]
        public async Task<IActionResult> ImportProgrammes([FromForm] IFormFileCollection file)
        {
           
            var reader = new StreamReader(file[0].OpenReadStream());
            var totaluploaded = 0;
            var totalfailed = 0;

            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            List<ProgrammeImportDto> programmeList = csv.GetRecords<ProgrammeImportDto>().ToList();
          

            var departments = _unitOfWork.departmentRepository.FindAll();
            var programmetypes = _unitOfWork.programmeTypeRepository.FindAll();


            if (programmeList.ToList().Count > 0)
            {

                foreach (var programme in programmeList.ToList())
                {
                    var departmentname = programme.DepartmentName;
                    var department = departments.Where(q => q.Name.ToLower() == departmentname.ToLower()).First();
                    var programmetype = programmetypes.Where(q => q.Name.ToLower() == programme.ProgrammeType.ToLower()).FirstOrDefault();
                    var newcode = Regex.Replace(programme.NewCode, @"[^0-9a-zA-Z\._]", "");
                    var checkprogramme = _unitOfWork.programmeRepository.GetOne(q => q.Code.ToUpper() == newcode.ToUpper());
                    var checkhistory = _unitOfWork.programmehistoryRepository.GetOne(q => q.Code == programme.Code);
                    if (checkprogramme == null)
                    {
                        Programme prog = new Programme { Code = newcode, Description = programme.Description, DepartmentId = department.Id, ProgrammeTypeId = programmetype.Id,Status="ACTIVE" };
                        _unitOfWork.programmeRepository.Add(prog);
                        var result = await _unitOfWork.Save();
                        if (result > 0)
                        {
                            totaluploaded++;
                            ProgrammeHistory programmeHistory = new ProgrammeHistory();
                            programmeHistory.ProgrammeId = prog.Id;
                            programmeHistory.Code = programme.Code;
                            _unitOfWork.programmehistoryRepository.Add(programmeHistory);
                            var rslt = await _unitOfWork.Save();
                        }
                        else
                        {
                            totalfailed++;
                        }

                    }
                    else
                    {
                        if (checkhistory == null)
                        {
                            ProgrammeHistory programmeHistory = new ProgrammeHistory();
                            programmeHistory.ProgrammeId = checkprogramme.Id;
                            programmeHistory.Code = programme.Code;
                            _unitOfWork.programmehistoryRepository.Add(programmeHistory);
                            var rslt = await _unitOfWork.Save();
                        }
                    }
                }
            }





            _response.Status = true;
            _response.Message = $"{totaluploaded} Records succesfully created, {totalfailed} failed";

            return Ok(_response);


        }

    }
}
