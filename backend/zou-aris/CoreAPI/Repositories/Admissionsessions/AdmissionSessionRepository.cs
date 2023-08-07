using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissionsessions
{
    public class AdmissionSessionRepository:GenericRepository<AdmissionSession>,IAdmissionSessionRepository
    {
        public AdmissionSessionRepository(CoreDbContext context):base(context)
        {

        }

        public async Task<AdmissionSession> GetCurrent()
        {
            
            var session = await _context.admissionsessions.Include(q=>q.applications)
                                        .Where(q => q.IsPublished == true)
                                        .OrderBy(x => x.Id)
                                        .LastOrDefaultAsync();
            var comparedate = DateTime.Compare(DateTime.Parse(session.EndDate), DateTime.Now);
            if (session != null && comparedate < 0)
            {
                session = new AdmissionSession();
            }
            if (session == null)
            {
                session = new AdmissionSession();
            }
            return session;
        }
    }
}
