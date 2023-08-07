using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantsubjects
{
    public class ApplicantSubjectRepository:GenericRepository<ApplicantSubject>,IApplicantSubjectRepository
    {
        public ApplicantSubjectRepository(CoreDbContext context):base(context) { }
       
    }
}
