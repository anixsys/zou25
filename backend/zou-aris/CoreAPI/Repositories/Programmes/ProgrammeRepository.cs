using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Programmes
{
    public class ProgrammeRepository:GenericRepository<Programme>,IProgrammeRepository
    {
        public ProgrammeRepository(CoreDbContext context):base(context)  
        {

        }

        public async Task<List<Programme>> GetByAdmissionTemplate(int id)
        {
            return await _context.programmes
                                  .Include(q=>q.Department)
                                  .Where(q=>q.Status=="ACTIVE" && q.ProgrammeTypeId==id)
                                  
                                 .ToListAsync();
        }
    }
}
