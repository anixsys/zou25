using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Emails
{
    public class EmailRepository : GenericRepository<EmailQueue>, IEmailRepository
    {
        public EmailRepository(CoreDbContext context) : base(context) { }


        public async Task<List<EmailQueue>> GetPending()
        {
            return await  _context.emailqueues.ToListAsync();
        }
    }
}
