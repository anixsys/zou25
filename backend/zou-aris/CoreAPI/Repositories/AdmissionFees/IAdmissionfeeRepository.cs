using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.AdmissionFees
{
    public interface IAdmissionfeeRepository:IGenericRepository<AdmissionFee>
    {
        Task<AdmissionFee> getFee(int ApplicanttypeId, int ProgrammeTypeId, int CurrencyId);
    }
}
