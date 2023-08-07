using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Systemmodules
{
    public class SystemmoduleRepository : GenericRepository<Systemmodule>, ISystemmoduleRepository
    {
        public SystemmoduleRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
