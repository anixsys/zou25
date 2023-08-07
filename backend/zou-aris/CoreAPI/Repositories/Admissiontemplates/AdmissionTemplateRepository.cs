using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissiontemplates
{
 public class AdmissionTemplateRepository:GenericRepository<Admissiontemplate>,IAdmissionTemplateRepository
    {
        public AdmissionTemplateRepository(CoreDbContext context):base(context)
        {

        }
    }
}
