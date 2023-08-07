using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicationentrymodes
{
    public class ApplicationEntryModeDocumentRepository:GenericRepository<ApplicationEntryModeDocument>,IApplicationEntryModeDocumentRepository
    {
        public ApplicationEntryModeDocumentRepository(CoreDbContext context):base(context)
        {

        }
    }
}
