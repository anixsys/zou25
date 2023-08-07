using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantsubjects
{
    public interface IApplicantSubjectRepository:IGenericRepository<ApplicantSubject>
    {
    }
}
