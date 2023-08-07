using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Documents
{
    public interface IDocumentRepository:IGenericRepository<Document>
    {
    }
}
