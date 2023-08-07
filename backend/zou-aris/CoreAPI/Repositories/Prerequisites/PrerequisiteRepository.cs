using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Prerequisites
{
    public class PrerequisiteRepository : GenericRepository<Prerequisite>, IPrerequisiteRepository
    {
        public PrerequisiteRepository(CoreDbContext context) : base(context)
        {

        }
    }
}
