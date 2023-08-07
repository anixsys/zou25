using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Systempermissions
{
    public class SystempermissionRepository : GenericRepository<Systempermission>, ISystempermissionRepository
    {
        public SystempermissionRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
