using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Systemsubmodules
{
    public class SystemsubmoduleRepository : GenericRepository<Systemsubmodule>, ISystemsubmoduleRepository
    {
        public SystemsubmoduleRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
