using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.RegistrationFees
{
    public class RegistrationFeeRepository : GenericRepository<RegistrationFee>, IRegistrationFeeRepository
    {
        public RegistrationFeeRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
