using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantotherqualifications
{
    public class ApplicantOtherqualificationRepository:GenericRepository<ApplicantOtherqualification>,IApplicantOtherqualificationRepository
    {
        public ApplicantOtherqualificationRepository(CoreDbContext context):base(context) { }
        
    }
}
