using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Semesters
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(CoreDbContext context) : base(context)
        {
        }

        public async Task<Semester> GetLatest()
        {
            return await _context.semesters
                                 .Include(q => q.registrationperiods)
                                 .Include(q => q.examinationperiods)
                                 .OrderBy(q => q.Id)
                                 .LastOrDefaultAsync();
        }
    }
}
