using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralregulationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public GeneralregulationController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = _unitOfWork.generalregulationRepository.FindAll(new List<string>() { "globalsettingtemplate", "programmeType" }).ToList();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var response = _unitOfWork.generalregulationRepository.GetOne(q => q.Id == id, new List<string>() { "globalsettingtemplate", "programmeType", "generalregulationacademicrules", "generalregulationregistrationrules" });

            return Ok(response);
        }

        [HttpGet("retrieve/programmetype/{id:int}")]
        public async Task<ActionResult> RetrieveByPrgrammeType(int id)
        {
            var response = _unitOfWork.generalregulationRepository.Find(q => q.ProgrammetypeId == id).ToList(); 
            return Ok(response);
        }

        [HttpGet("duplicate/{id:int}")]
        [Authorize(Roles ="GR.DUPLICATE")]
        public async Task<ActionResult> Duplicate(int id)
        {
            var record = _unitOfWork.generalregulationRepository.GetOne(q => q.Id == id, new List<string>() { "generalregulationacademicrules", "generalregulationregistrationrules" });

            Generalregulation generalregulation = new Generalregulation();
            generalregulation.Name = record.Name + "_1";
            generalregulation.Description = record.Description;
            generalregulation.Year = record.Year;
            generalregulation.Status = "PENDING";
            generalregulation.ProgrammetypeId = record.ProgrammetypeId;
            generalregulation.GlobalsettingtemplateId = record.GlobalsettingtemplateId;
            List<Generalregulationacademicrule> generalregulationacademicrules = new List<Generalregulationacademicrule>();
            Generalregulationregistrationrule generalregulationregistrationrule = new Generalregulationregistrationrule();

            _unitOfWork.generalregulationRepository.Add(generalregulation);
            var result = await _unitOfWork.Save();
            if (record.generalregulationacademicrules.Count() > 0)
            {
                foreach (var academic in record.generalregulationacademicrules)
                {
                    generalregulationacademicrules.Add(new Generalregulationacademicrule { GeneralregulationId = generalregulation.Id, level = academic.level, semester = academic.semester, requiredlevel = academic.requiredlevel, requiredsemester = academic.requiredsemester, corepercentage = academic.corepercentage, electivepercentage = academic.electivepercentage });
                }

                _unitOfWork.generalregulationacademicruleRepository.BulkInsert(generalregulationacademicrules);
                await _unitOfWork.Save();
            }

            if (record.generalregulationregistrationrules.Count() > 0)
            {
                foreach (var item in record.generalregulationregistrationrules)
                {
                    generalregulationregistrationrule.GeneralregulationId = generalregulation.Id;
                    generalregulationregistrationrule.maximumcourses = item.maximumcourses;

                }
                _unitOfWork.generalregulationregistrationruleRepository.Add(generalregulationregistrationrule);
                await _unitOfWork.Save();
            }


            if (result > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully added";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Record creation failed";
            }
            return Ok(_response);
        }

        [HttpPost]
        [Authorize(Roles = "GR.CREATE")]
        public async Task<IActionResult> Create([FromBody] GeneralregulationRequestDto dto)
        {
            var generalregulation = _mapper.Map<Generalregulation>(dto);
            generalregulation.Status = "PENDING";
            _unitOfWork.generalregulationRepository.Add(generalregulation);
            var response = await _unitOfWork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully added";
            }
            else
            {
                _response.Status = false;
                _response.Message = "Record creation failed";
            }
            return Ok(_response);
        }
        [HttpPut]
        [Authorize(Roles = "GR.UPDATE")]
        public async Task<IActionResult> Update([FromBody] GeneralregulationRequestDto dto)
        {
            var generalregulation = _mapper.Map<Generalregulation>(dto);
            _unitOfWork.generalregulationRepository.Update(generalregulation);
            var response = await _unitOfWork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Record successfully Updated";
            }
            else
            {
                _response.Status = false;
                _response.Message = "record modification failed";
            }

            return Ok(_response);
        }
        [HttpPut("ChangeStatus")]
        [Authorize(Roles = "GR.CHANGESTATUS")]
        public async Task<IActionResult> Update([FromBody] ChangeStatusDto changeStatusDto)
        {
            var record = _unitOfWork.generalregulationRepository.GetOne(q => q.Id == changeStatusDto.Id);
            if (record == null)
            {

                _response.Status = false;
                _response.Message = "Record not found";

            }
            else
            {
                record.Status = changeStatusDto.Status;
                _unitOfWork.generalregulationRepository.Update(record);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Record update failed";
                }
            }

            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "GR.DELETE")]
        public async Task<IActionResult> Delete(int id)
        {

            var regulation = _unitOfWork.generalregulationRepository.GetOne(q => q.Id == id);
            if (regulation != null)
            {
                _unitOfWork.generalregulationRepository.Remove(regulation);
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
