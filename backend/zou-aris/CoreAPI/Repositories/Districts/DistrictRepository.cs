using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Districts
{
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        public DistrictRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
