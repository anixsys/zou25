using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Documents
{
    public class DocumentRepository:GenericRepository<Document>,IDocumentRepository
    {
        public DocumentRepository(CoreDbContext context):base(context)
        {

        }
    }
}
