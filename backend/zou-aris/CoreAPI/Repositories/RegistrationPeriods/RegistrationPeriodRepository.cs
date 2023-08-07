using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.RegistrationPeriods
{
    public class RegistrationPeriodRepository : GenericRepository<RegistrationPeriod>, IRegistraationPeriodRepository
    {
        public RegistrationPeriodRepository(CoreDbContext context) : base(context)
        {
        }

        public async Task<RegistrationPeriod> GetLastsync(int semesterId)
        {
            return await _context.registrationPeriods.Where(q =>q.SemesterId==semesterId && q.Status == "APPROVED").OrderBy(q => q.Id).LastOrDefaultAsync();

        }

        public async Task<RegistrationPeriod> GetLatestAsync()
        {
            return await _context.registrationPeriods.Where(q => q.Status == "APPROVED").OrderBy(q => q.Id).LastOrDefaultAsync();
        }
    }
}
