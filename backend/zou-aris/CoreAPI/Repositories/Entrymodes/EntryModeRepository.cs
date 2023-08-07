using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Entrymodes
{
    public class EntryModeRepository:GenericRepository<EntryMode>,IEntryModeRepository
    {
        public EntryModeRepository(CoreDbContext context):base(context)
        {

        }
    }
}
