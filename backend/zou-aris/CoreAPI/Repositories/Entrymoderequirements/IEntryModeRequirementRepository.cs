using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Entrymoderequirements
{
    public interface IEntryModeRequirementRepository:IGenericRepository<EntryModeRequirement>
    {
        Task<List<EntryModeRequirement>> GetByApplication(int EntryModeId, int ApplicationId);
    }
}
