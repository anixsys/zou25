
using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using CoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharpCore;
using PdfSharpCore.Pdf;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IHttpContextAccessor _context;
        private readonly HelperFunctions _helper;
        private readonly IConfiguration _configuration;

        public ApplicationController(IUnitOfWork unitofwork,HelperFunctions helper,IConfiguration configuration, ResponseDto response, IMapper mapper, IHttpContextAccessor context)
        {
            _unitOfWork = unitofwork;
            _response = response;
            _mapper = mapper;
            _context = context;
            _helper = helper;
            _configuration = configuration;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAll(int id)
        {
            var response = _unitOfWork.applicationRepository.Find(q => q.AdmissionSessionId == id, new List<string>() { "applicant", "applicationentrymodes.modeRequirement", "applicant.documents.admissionDocument.document", "applicant.subjects.subject", "applicant.otherqualifications", "applicant.workexperiences", "applicanttype", "attendenceType", "Campus", "programmeType", "admissionSession", "user", "applicationprogrammes.programme" }).ToList();

            return Ok(response);
        }
        [HttpGet("record/{uuid}")]
        public async Task<ActionResult> Get(string uuid)
        {
            var dbresponse = _unitOfWork.applicationRepository.GetOne(q => q.uuid == uuid, new List<string>() { "applicant", "applicant.studentnumber", "applicanttype", "attendenceType", "Campus", "programmeType", "admissionSession", "applicationprogrammes.programme" });

            ;
            var document = new PdfDocument();
           var imageUrl = @"data:image/png;base64," + Getbase64String();
            var signatureUrl = @"data:image/png;base64," +Getbase64SignatureString();   
            var htmlContent = await _helper.GenerateOfferLetter(dbresponse,imageUrl,signatureUrl);
            PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);
            byte[]? response = null;
            using(MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Offerletter_" + uuid + ".pdf";
            return File(response, "application/pdf", Filename);
        }

        [HttpGet("Submitforreview/{id:int}")]
        [Authorize(Roles = "APPL.CREATE")]
        public async Task<ActionResult> SubmitforReview(int id)
        {
            var applicaiton = _unitOfWork.applicationRepository.GetOne(q => q.Id == id);
            if (applicaiton == null)
            {
                _response.Status = true;
                _response.Message = "Application not found";
            }
            else
            {
                applicaiton.ApprovalStatus = "AWAITING";
                _unitOfWork.applicationRepository.Update(applicaiton);
                await _unitOfWork.Save();
                _response.Status = true;
                _response.Message = "Application successfully submitted for review";
            }
            return Ok(_response);
        }
        [HttpGet("decision/rejectall/{id:int}")]
        [Authorize(Roles = "APPL.DECISION")]
        public async Task<IActionResult> RejectAll(int id)
        {
            var application = _unitOfWork.applicationRepository.GetOne(q => q.Id == id, new List<string>() { "applicationprogrammes", "applicant", "Campus" });
            if (application == null)
            {
                _response.Status = false;
                _response.Message = "Application not found";
            }
            else
            {

                var checkaccess = await _helper.CheckCampusAccess(application.CampusId);
                if (!checkaccess)
                {
                    _response.Status = false;
                    _response.Message = $"You do not  have permissions to make application decision for students applying at {application.Campus.Name}";
                }
                else
                {
                    application.ApprovalStatus = "REJECTED";
                    application.UserId = _helper.GetLoggedAdministratorId();
                    string institution = _configuration.GetSection("INSTITUTIONNAME").Value;

                    foreach (var item in application.applicationprogrammes)
                    {
                        item.Status = "REJECTED";
                        _unitOfWork.applicationProgrammeRepository.Update(item);
                        await _unitOfWork.Save();
                    }
                    _unitOfWork.applicationRepository.Update(application);

                    var result = await _unitOfWork.Save();
                    if (result > 0)
                    {
                        var htmlmessage = $"<h4>Dear : {application.applicant.Name} {application.applicant.Surname}</h4>"
                           + $"<p>We regret to inform you that your application with reference number {application.AppNumber} was not successful</p>"
                           + "<p>We thank you for considering us your academic partner</p>"
                           + "<p>Admissions Department</p>"
                           + $"<p>{institution}</p>";
                        var subject = $"Unsuccessful application to Study at {institution}";
                        var email = application.applicant.Email;
                        var emailqueue = new EmailQueue();
                        emailqueue.Email = email;
                        emailqueue.Name = application.applicant.Name + " " + application.applicant.Surname;
                        emailqueue.Subject = subject;
                        emailqueue.BodyHtml = htmlmessage;
                        emailqueue.Status = "PENDING";
                        _unitOfWork.emailRepository.Add(emailqueue);
                        await _unitOfWork.Save();

                        // send http request to  online applicaton portal

                        _response.Status = true;
                        _response.Message = "Decision successully saved";
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


        [HttpPost]
        [Authorize(Roles = "APPL.CREATE")]
        public async Task<IActionResult> Create([FromBody] ApplicationDto dto)
        {
            var check = _unitOfWork.applicationRepository.Find(q => q.AdmissionSessionId == dto.AdmissionSessionId && q.applicantId == dto.ApplicantId).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Applicant has an application in current session";
            }
            else
            {
                Random rn = new Random();
                Application application = new Application();
                application.uuid = Guid.NewGuid().ToString();
                application.AppNumber = "App-" + rn.Next();
                application.AdmissionSessionId = dto.AdmissionSessionId;
                application.ApplicanttypeId = dto.ApplicanttypeId;
                application.attendencetypeId = dto.AttendenceTypeId;
                application.CampusId = dto.CampusId;
                application.ProgrammeTypeId = dto.ProgrammeTypeId;
                application.applicantId = dto.ApplicantId;
                application.EntryModeId = dto.EntryModeId;
                application.PaymentStatus = "PENDING";
                application.ApprovalStatus = "PENDING";
                _unitOfWork.applicationRepository.Add(application);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {

                    _response.Status = true;
                    _response.Message = "Application successfully created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error occurred while creating application";
                }

            }
            return Ok(_response);
        }
        [HttpPost("decision/accepted")]
        [Authorize(Roles= "APPL.DECISION")]
        public async Task<IActionResult> Accepted([FromBody] AcceptedDto dto)
        {
            var application = _unitOfWork.applicationRepository.GetOne(q => q.Id == dto.applicationId, new List<string>() { "applicationprogrammes.programme","Campus", "applicant" });
            if (application == null)
            {
                _response.Status = false;
                _response.Message = "Application not found";
            }
            else
            {
                var checkaccess = await _helper.CheckCampusAccess(application.CampusId);
                if (!checkaccess)
                {
                    _response.Status = false;
                    _response.Message = $"You do not  have permissions to make application decision for students applying at {application.Campus.Name}";
                }
                else
                {
                    application.ApprovalStatus = "ACCEPTED";
                    string programme = "";
                    string institution = _configuration.GetSection("INSTITUTIONNAME").Value;
                    string url = _configuration.GetSection("APPLYURL").Value;
                    foreach (var item in application.applicationprogrammes)
                    {
                        if (item.Id == dto.applicationprogrammeId)
                        {
                            item.Status = "ACCEPTED";
                            programme = item.programme.Description;
                        }
                        else
                        {
                            item.Status = "REJECTED";
                        }
                        _unitOfWork.applicationProgrammeRepository.Update(item);
                        await _unitOfWork.Save();

                    }
                    _unitOfWork.applicationRepository.Update(application);
                    var result = await _unitOfWork.Save();
                    if (result > 0)
                    {
                        ////generate student number 
                        var checkstudentnumber = _unitOfWork.applicantStudentRepository.Find(q => q.nationalId == application.applicant.identification).ToList();
                        if (checkstudentnumber.Count() == 0)
                        {
                            var studentnumber = _helper.GenerateStudentNumber();
                            ApplicantStudentnumber applicantStudentnumber = new ApplicantStudentnumber();
                            applicantStudentnumber.applicantId = application.applicantId;
                            applicantStudentnumber.nationalId = application.applicant.identification;
                            applicantStudentnumber.AdmissionSessionId = application.AdmissionSessionId;
                            applicantStudentnumber.applicationId = application.Id;
                            applicantStudentnumber.studentnumber = studentnumber;

                            _unitOfWork.applicantStudentRepository.Add(applicantStudentnumber);
                            await _unitOfWork.Save();
                        }


                        ///send email to applicant
                        var htmlmessage = $"<h4>Dear : {application.applicant.Name} {application.applicant.Surname}</h4>"
                                 + $"<p>We are pleased to inform you that your application with reference number {application.AppNumber} has been accepted</p>"
                                 + $"<p>Your have been accepted for <b>{programme}</b></p>"
                                 + "<p>Below are required steps to commernce your studies</p>"
                                 + "<p><ol>"
                                 + $"<li>Login to your online application profile and download  your offer letter <a href='{url}'>Click Here</a></li<"
                                 + "<li>Visit any of our Campus  closes to you with original identification and academic results</li>"
                                 + "<li>Once your documents have been verified  activate your student account</li>"
                                 + "</ol></p>"
                                 + "<p>Congratulations on being accepted to join a vibrant and dynamic institution.</p>"
                                 + "<p>Admissions Department</p>"
                                 + $"<p>{institution}</p>";
                        var subject = $"Acceptance to Study at {institution}";
                        var email = application.applicant.Email;
                        var emailqueue = new EmailQueue();
                        emailqueue.Email = email;
                        emailqueue.Name = application.applicant.Name + " " + application.applicant.Surname;
                        emailqueue.Subject = subject;
                        emailqueue.BodyHtml = htmlmessage;

                        ///update  applicant online portal

                        _response.Status = true;
                        _response.Message = "Decision successully saved";
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
        [HttpPut]
        [Authorize(Roles = "APPL.UPDATE")]
        public async Task<IActionResult> Update([FromBody] ApplicationDto dto)
        {

            var application = _unitOfWork.applicationRepository.GetOne(q => q.Id == dto.Id);
            application.PaymentStatus = dto.PaymentStatus;
            application.ApprovalStatus = dto.ApprovalStatus;
            application.AdmissionSessionId = dto.AdmissionSessionId;
            application.ApplicanttypeId = dto.ApplicanttypeId;
            application.attendencetypeId = dto.AttendenceTypeId;
            application.CampusId = dto.CampusId;
            application.ProgrammeTypeId = dto.ProgrammeTypeId;
            application.EntryModeId = dto.EntryModeId;
            _unitOfWork.applicationRepository.Update(application);
            await _unitOfWork.Save();
            _response.Status = true;
            _response.Message = "Application successfully Updated";

            return Ok(_response);
        }

        [NonAction]
        public string Getbase64String()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logo", "logo.jpg");
            byte[] imagearray = System.IO.File.ReadAllBytes(filepath);
            string base64 = Convert.ToBase64String(imagearray);
            return base64;
        }

        [NonAction]
        public string Getbase64SignatureString()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logo", "signature.jpg");
            byte[] imagearray = System.IO.File.ReadAllBytes(filepath);
            string base64 = Convert.ToBase64String(imagearray);
            return base64;
        }
    }
}
