using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Roles
{
    public interface IRoleRepository:IGenericRepository<Role>
    {
        Task<Role> GetSystemModule(string id);

        Task<List<Systemmodule>> GetAllSystems(string id);
    }
}
