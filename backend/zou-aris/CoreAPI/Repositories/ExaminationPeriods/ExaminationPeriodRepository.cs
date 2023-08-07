using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.ExaminationPeriods
{
    public class ExaminationPeriodRepository : GenericRepository<ExaminationPeriod>, IExaminationPeriodRepository
    {
        public ExaminationPeriodRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
