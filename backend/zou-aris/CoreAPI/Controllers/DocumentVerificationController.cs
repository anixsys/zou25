using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CoreAPI.Services;
using CoreAPI.Services.Auth;
using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentVerificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly ResponseDto _response;
        private readonly HelperFunctions _helpers;
        private readonly IAuthService _authservice;
        public DocumentVerificationController(IUnitOfWork unitofwork,ResponseDto response,HelperFunctions helpers,IAuthService authservice)
        {
              _response = response;
              _unitofwork = unitofwork;
            _helpers = helpers;
            _authservice = authservice;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var records = _unitofwork.applicantStudentRepository.Find(q => q.Id == id, new List<string> { "applicant.documents.admissionDocument.document", "admissionSession", "application.applicationprogrammes.programme" });
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles ="DV.SEARCH")]
        public async Task<IActionResult> Search([FromBody] ApplicationSearchDto dto)
        {
             var application = _unitofwork.applicationRepository.GetOne(q=>q.AppNumber == dto.AppNumber, new List<string> { "applicant", "applicant.studentnumber", "applicationentrymodes.modeRequirement", "applicant.documents.admissionDocument.document" });
            return Ok(application);
        }

        [HttpGet("verify/{id:int}")]
        [Authorize(Roles = "DV.VERIFY")]
        public async Task<IActionResult> Verify(int id)
        {
            var user = await _authservice.GetCurrentUser();
            var applicationstudent = _unitofwork.applicantStudentRepository.GetOne(q => q.applicationId == id,new List<string> { "application.admissionSession", "applicant" });

            if (applicationstudent == null)
            {
                _response.Status = false;
                _response.Message = "Applicant Not Found";
            }
            else
            {
                var accepted = _unitofwork.applicationProgrammeRepository.GetOne(q => q.applicationId == applicationstudent.applicationId && q.Status == "ACCEPTED");
                if (accepted == null)
                {
                    _response.Status = false;
                    _response.Message = "No record of an accepted programme was found";
                }
                else
                {
                    var academicregulation = await _unitofwork.academicregulationRepository.GetLatest(accepted.ProgrammeId, accepted.AttendenceTypeId);
                    if (academicregulation == null)
                    {
                        _response.Status = false;
                        _response.Message = "No Active Regulation was found for Accepted programme please contact System Administrator";
                    }
                    else
                    {

                        applicationstudent.DocVerified = "Y";
                        applicationstudent.UserId = user.Id;
                        _unitofwork.applicantStudentRepository.Update(applicationstudent);
                        var response = await _unitofwork.Save();
                        if (response > 0)
                        {
                            Student student = new Student();
                            student.Name = applicationstudent.applicant.Name;
                            student.Gender = applicationstudent.applicant.Gender;
                            student.Dob = applicationstudent.applicant.DOB;
                            student.Intake = applicationstudent.application.admissionSession.Name;
                            student.Surname = applicationstudent.applicant.Surname;
                            student.CampusId = applicationstudent.application.CampusId;
                            student.Identificationtype = applicationstudent.applicant.IdentificationType;
                            student.Identificationnumber = applicationstudent.applicant.identification;
                            student.Title = applicationstudent.applicant.Title;
                            student.Email = applicationstudent.applicant.Email;
                            student.Pin = applicationstudent.studentnumber;
                            student.Pushed = "N";

                            _unitofwork.studentRepository.Add(student);
                            var result = await _unitofwork.Save();
                            if (result > 0)
                            {
                                ///// get latest regulations
                                ///
                                StudentProgramme studentprogramme = new StudentProgramme();
                                studentprogramme.StudentId = student.Id;
                                studentprogramme.ProgrammeId = accepted.ProgrammeId;
                                studentprogramme.AcademicRegulationId = academicregulation.Id;
                                studentprogramme.AttendenceTypeId = academicregulation.AttendencetypeId;
                                studentprogramme.Status = "PENDING";
                                _unitofwork.studentProgrammeRepository.Add(studentprogramme);
                                var result2 = await _unitofwork.Save();
                                if (result2 > 0)
                                {
                                    _response.Status = true;
                                    _response.Message = "Documents Successfully Verified";
                                }

                            }


                        }
                    }
                }
            }
            return Ok(_response);
        }


    }
}
