using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Globalsettingtemplates
{
    public class GlobalsettingtemplateRepository:GenericRepository<Globalsettingtemplate>,IGlobalsettingtemplateRepository
    {
        public GlobalsettingtemplateRepository(CoreDbContext context):base(context)
        {

        }
    }
}
