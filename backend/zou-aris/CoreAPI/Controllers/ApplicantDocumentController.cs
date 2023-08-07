using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;


namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantDocumentController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        private readonly IHttpContextAccessor _context;
        public ApplicantDocumentController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper, IHttpContextAccessor context)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDocuments(int id)
        {
            var application = _unitofwork.applicationRepository.GetOne(q => q.Id == id);
            var responses = _unitofwork.admissionDocumentRepository.GetByApplicant(application.applicantId, application.ApplicanttypeId, application.ProgrammeTypeId, new List<string>() { "Document" });
            return Ok(responses);
        }
        [HttpGet("verified/{id:int}")]
        [Authorize(Roles ="APD.DOC.VERIFY")]
        public async Task<IActionResult> Verified(int id)
        {
            var record = _unitofwork.applicantDocumentRepository.GetOne(q => q.Id == id);
            var userId = _context.HttpContext.User.Identity.Name;
            if (record == null)
            {
                _response.Status = false;
                _response.Message = "record not found";
            }
            else
            {
                record.Verified = "VERIFIED";
                record.VerifiedBy = userId;
                _unitofwork.applicantDocumentRepository.Update(record);
                await _unitofwork.Save();
                _response.Status = true;
                _response.Message = "Applicant document verified";
            }
            return Ok(_response);  
        }
        [HttpGet("viewdocument/{filename}")]
        public async Task<IActionResult> ViewFile(string filename)
        {

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "applicants", filename);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes =  System.IO.File.OpenRead(filepath);
            return File(bytes, contentType, Path.GetFileName(filepath));
        }
       

    [HttpPost]
      //  [Authorize(Roles = "APD.UPLOAD")]
        public async Task<IActionResult> CreateDocument([FromForm] IFormFile file)
        {
            var userId = _context.HttpContext.User.Identity.Name;
            var applicantId = HttpContext.Request.Form["ApplicantId"].ToString();
            var documentId = HttpContext.Request.Form["DocumentId"].ToString();
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "applicants", filename);
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
            }

            ApplicantDocument document = new ApplicantDocument();
            document.applicantId = int.Parse(applicantId);
            document.admissiondocumentId= int.Parse(documentId);
            document.filename = filename;
            var check = _unitofwork.applicantDocumentRepository.Find(q => q.applicantId == document.applicantId && q.admissiondocumentId == document.admissiondocumentId).ToList();
            if (check.Count() > 0)
            {
                _response.Status = false;
                _response.Message = "Document already added";
            }
            else
            {
                _unitofwork.applicantDocumentRepository.Add(document);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Required Document successfully added to application";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "An error occured  while trying to save record";
                }
            }
            return Ok(_response);

        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "APD.DELETE")]
        public async Task<IActionResult> RemoveDocument(int id)
        {
            var applicationdocument = _unitofwork.applicantDocumentRepository.GetOne(q => q.Id == id);
            if (applicationdocument == null)
            {
                _response.Status = false;
                _response.Message = "Record not found";
            }
            else
            {

                _unitofwork.applicantDocumentRepository.Remove(applicationdocument);
                var result = await _unitofwork.Save();
                if (result > 0)
                {
                    _response.Status = true;
                    _response.Message = "Record successfully removed";
                }

            }

            return Ok(_response);
        }
     }
}
