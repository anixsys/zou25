using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Rolesystemsubmodules
{
    public class RolesystemsubmoduleRepository : GenericRepository<RoleSystemsubmodule>, IRolesystemsubmoduleRepository
    {
        public RolesystemsubmoduleRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
