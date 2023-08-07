using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.AdmissionFees
{
    public class AdmissionfeeRepository:GenericRepository<AdmissionFee>,IAdmissionfeeRepository
    {
        public AdmissionfeeRepository(CoreDbContext context):base(context) 
        {

        }

        public async Task<AdmissionFee> getFee(int ApplicanttypeId, int ProgrammeTypeId, int CurrencyId)
        {
            var record = await this._context.admissionfeetemplates.Include(q=>q.admissionFees.Where(q=>q.CurrencyId==CurrencyId && q.ApplicanttypeId==ApplicanttypeId && q.ProgrammeTypeId==ProgrammeTypeId)).ThenInclude(q=>q.Currency).Where(q => q.Status == "PUBLISHED").OrderBy(q => q.Id).LastOrDefaultAsync();
            return record.admissionFees.FirstOrDefault();
        }
    }
}
