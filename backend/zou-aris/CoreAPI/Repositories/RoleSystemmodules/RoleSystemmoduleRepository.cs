using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.RoleSystemmodules
{
    public class RoleSystemmoduleRepository : GenericRepository<RoleSystemmodule>, IRoleSystemmoduleRepository
    {
        public RoleSystemmoduleRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
