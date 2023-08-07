using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Campustypes
{
    public class CamputTypeRepository : GenericRepository<CampusType>, ICampusTypeRepository
    {
        public CamputTypeRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
