using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissionsesssiontemplates
{
    public class AdmissionsessiontemplateRepository:GenericRepository<Admissionsessiontemplate>,IAdmissionsessiontemplateRepository
    {
        public AdmissionsessiontemplateRepository(CoreDbContext context) : base(context)
        {

        }
    }
}