using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.AdmissionDocuments
{
    public interface IAdmissionDocumentRepository : IGenericRepository<AdmissionDocument>
    {
        List<AdmissionDocument> GetByApplicant(int applicantId, int applicanttypeId, int programmeTypeId, List<string> list);
    }
}
