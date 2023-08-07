using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantworkexperiences
{
    public class ApplicantWorkExperienceRepository:GenericRepository<ApplicantWorkexperience>,IApplicantWorkExperienceRepository
    {
        public ApplicantWorkExperienceRepository(CoreDbContext context):base(context) { }
        
    }
}
