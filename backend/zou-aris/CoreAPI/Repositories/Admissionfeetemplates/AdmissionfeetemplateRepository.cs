using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissionfeetemplates
{
    public class AdmissionfeetemplateRepository:GenericRepository<AdmissionFeeTemplate>,IAdmissionfeetampleRepository
    {
        public AdmissionfeetemplateRepository(CoreDbContext context):base(context)
        {

        }
    }
}
