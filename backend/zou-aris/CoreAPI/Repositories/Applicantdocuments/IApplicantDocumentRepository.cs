using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantdocuments
{
    public interface IApplicantDocumentRepository:IGenericRepository<ApplicantDocument>
    {
    }
}
