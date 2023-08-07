using AutoMapper;
using CoreAPI.Dto;
using CoreAPI.Models;
using CoreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationEntryModeDocumentController : ControllerBase
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;
        public ApplicationEntryModeDocumentController(IUnitOfWork unitofwork, ResponseDto response, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> getDocuments(int id) { 
        var application = _unitofwork.applicationRepository.GetOne(q=>q.Id==id);
            if (application == null) {
                _response.Status = false;
                _response.Message = "Applicant not found";
            }
              var documents = await _unitofwork.entryModeRequirementRepository.GetByApplication(application.EntryModeId,application.Id);
         return Ok(documents);
        }

       

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var applicantId = HttpContext.Request.Form["ApplicationId"].ToString();
            var documentId = HttpContext.Request.Form["DocumentId"].ToString();
            var fileextension = Path.GetExtension(file.FileName);
            var filename = Guid.NewGuid().ToString() + fileextension;
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "applicants", filename);
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
            }

            ApplicationEntryModeDocument document = new ApplicationEntryModeDocument();
            document.ApplicationId = int.Parse(applicantId);
            document.EntryModeRequirementId = int.Parse(documentId);
            document.filename= filename;

            _unitofwork.applicationEntryModeDocumentRepository.Add(document);
            var response = await _unitofwork.Save();
            if (response > 0)
            {
                _response.Status = true;
                _response.Message = "Document successfully uploaded";
            }
            return Ok(_response);
        }
    }
}
