using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Generalregulations
{
    public class GeneralregulationRepository:GenericRepository<Generalregulation>,IGeneralregulationRepository
    {
        public GeneralregulationRepository(CoreDbContext context):base(context) { }
       
    }
}
