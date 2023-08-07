using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Campuses
{
    public class CampusRepository : GenericRepository<Campus>, ICampusRepository
    {
        public CampusRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
