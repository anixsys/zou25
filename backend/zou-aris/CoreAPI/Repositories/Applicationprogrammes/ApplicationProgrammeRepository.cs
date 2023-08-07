using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicationprogrammes
{
    public class ApplicationProgrammeRepository:GenericRepository<ApplicationProgramme>,IApplicationProgrammeRepository
    {
        public ApplicationProgrammeRepository(CoreDbContext context):base(context) { }
       
    }
}
