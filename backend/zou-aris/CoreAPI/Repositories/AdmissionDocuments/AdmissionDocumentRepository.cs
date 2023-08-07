using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.AdmissionDocuments
{
    public class AdmissionDocumentRepository:GenericRepository<AdmissionDocument>,IAdmissionDocumentRepository
    {
        public AdmissionDocumentRepository(CoreDbContext context):base(context)
        {

        }

        public List<AdmissionDocument> GetByApplicant(int applicantId, int applicanttypeId, int programmeTypeId, List<string> list)
        {
            return _context.admissiondocuments.Include(q=>q.applicantdocuments.Where(q=>q.applicantId==applicantId)).Include(q=>q.document).Where(q => q.ApplicantTypeId == applicanttypeId && q.ProgrammetypeId == programmeTypeId).ToList();
        }
    }
}
