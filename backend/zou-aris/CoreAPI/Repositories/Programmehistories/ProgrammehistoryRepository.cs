using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Programmehistories
{
    public class ProgrammehistoryRepository : GenericRepository<ProgrammeHistory>, IProgrammehistoryRepository
    {
        public ProgrammehistoryRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
