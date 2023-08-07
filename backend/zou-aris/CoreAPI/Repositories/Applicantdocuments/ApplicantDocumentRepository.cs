using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantdocuments
{
    public class ApplicantDocumentRepository:GenericRepository<ApplicantDocument>,IApplicantDocumentRepository
    {
        public ApplicantDocumentRepository(CoreDbContext context):base(context) { }
      
    }
}
