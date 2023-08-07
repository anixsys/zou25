using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Emails
{
    public interface IEmailRepository:IGenericRepository<EmailQueue>
    {
        Task<List<EmailQueue>> GetPending();
    }
}
