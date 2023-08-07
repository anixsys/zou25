using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Generalregulationacademicrules
{
    public class GeneralregulationacademicruleRepository:GenericRepository<Generalregulationacademicrule>,IGeneralregulationacademicruleRepository
    {
        public GeneralregulationacademicruleRepository(CoreDbContext context):base(context) 
        {

        }
    }
}
