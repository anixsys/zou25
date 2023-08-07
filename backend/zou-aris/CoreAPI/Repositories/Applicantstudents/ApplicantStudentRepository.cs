using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantstudents
{
    public class ApplicantStudentRepository:GenericRepository<ApplicantStudentnumber>,IApplicantStudentRepository
    {
        public ApplicantStudentRepository(CoreDbContext context):base(context)
        {

        }
    }
}
