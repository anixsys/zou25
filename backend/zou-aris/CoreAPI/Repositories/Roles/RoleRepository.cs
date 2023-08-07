using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Roles
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(CoreDbContext context) : base(context)
        {
        }

        public async Task<List<Systemmodule>> GetAllSystems(string id)
        {
            return await _context.systemmodules
                                 .Include(q => q.rolesystemmodules.Where(q => q.RoleId == id))
                                 .Include(q => q.submodules)
                                 .ThenInclude(q => q.rolesystemsubmodules.Where(q => q.RoleId == id))
                                 .Include(q => q.submodules)
                                 .ThenInclude(q => q.permissions)
                                 .ThenInclude(q => q.rolepermissions.Where(q => q.RoleId == id))
                                 .ToListAsync();
        }

        public async Task<Role> GetSystemModule(string id)
        {
            return await _context.Roles
                          .Include(q => q.systemmodules)
                          .ThenInclude(q => q.systemmodule)
                          .Include(q => q.systemmodules)
                          .ThenInclude(q => q.submodules)
                          .ThenInclude(q => q.systemsubmodule)
                          .Include(q => q.systemmodules)
                          .ThenInclude(q => q.submodules)
                          .ThenInclude(q => q.Rolesystempermissions)
                          .ThenInclude(q => q.permission)
                          .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
