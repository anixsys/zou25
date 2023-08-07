using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicanttypes
{
    public class ApplicabtTypeRepository:GenericRepository<Applicanttype>,IApplicantTypeRepository
    {
        public ApplicabtTypeRepository(CoreDbContext context):base(context)
        {

        }
    }
}
