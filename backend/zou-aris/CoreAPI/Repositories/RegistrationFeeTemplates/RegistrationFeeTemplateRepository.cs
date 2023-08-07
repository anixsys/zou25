using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.RegistrationFeeTemplates
{
    public class RegistrationFeeTemplateRepository : GenericRepository<RegistrationFeeTemplate>, IRegistrationFeeTemplateRepository
    {
        public RegistrationFeeTemplateRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
