using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Rolesystempermissions
{
    public class RolesystempermissionRepository : GenericRepository<RoleSystempermission>, IRolesystempermissionRepository
    {
        public RolesystempermissionRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
