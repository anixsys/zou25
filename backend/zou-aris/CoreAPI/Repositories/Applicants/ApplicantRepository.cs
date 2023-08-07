using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicants
{
    public class ApplicantRepository:GenericRepository<Applicant>,IApplicantRepository
    {
        public ApplicantRepository(CoreDbContext context):base(context)
        {

        }
    }
}
