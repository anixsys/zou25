using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Admissionsessions
{
    public interface IAdmissionSessionRepository:IGenericRepository<AdmissionSession>
    {
        Task<AdmissionSession> GetCurrent();
    }
}
