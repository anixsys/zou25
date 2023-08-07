using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.RegistrationPeriods
{
    public interface IRegistraationPeriodRepository:IGenericRepository<RegistrationPeriod>
    {
        Task<RegistrationPeriod> GetLatestAsync();

        Task<RegistrationPeriod> GetLastsync(int semesterId);
    }
}
