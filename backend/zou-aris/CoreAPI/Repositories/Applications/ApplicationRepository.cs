using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Applications
{
    public class ApplicationRepository:GenericRepository<Application>,IApplicationRepository
    {
        public ApplicationRepository(CoreDbContext context):base(context)
        {

        }
    }
}
