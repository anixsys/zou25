using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Entrymoderequirements
{
    public class EntryModeRequirementRepository:GenericRepository<EntryModeRequirement>,IEntryModeRequirementRepository
    {
        public EntryModeRequirementRepository(CoreDbContext context):base(context)
        {

        }

        public async Task<List<EntryModeRequirement>> GetByApplication(int EntryModeId, int ApplicationId)
        {
            return await _context.entrymoderequirements.Include(q => q.applications.Where(q => q.ApplicationId == ApplicationId)).Where(q => q.EntryModeId == EntryModeId).ToListAsync();
        }
    }
}
