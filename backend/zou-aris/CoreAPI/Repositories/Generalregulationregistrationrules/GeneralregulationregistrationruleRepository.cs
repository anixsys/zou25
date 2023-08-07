using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Generalregulationregistrationrules
{
    public  class GeneralregulationregistrationruleRepository:GenericRepository<Generalregulationregistrationrule>,IGeneralregulationregistrationruleRepository
    {
        public GeneralregulationregistrationruleRepository(CoreDbContext context):base(context) { }
      
    }
}
