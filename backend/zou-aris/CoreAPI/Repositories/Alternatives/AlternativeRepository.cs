using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Alternatives
{
   public class AlternativeRepository:GenericRepository<Alternative>,IAlternativeRepository
    {
        public AlternativeRepository(CoreDbContext context):base(context) { }
       
    }
}
