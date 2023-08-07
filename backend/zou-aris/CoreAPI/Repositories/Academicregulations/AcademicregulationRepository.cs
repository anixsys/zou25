using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Academicregulations
{
    public class AcademicregulationRepository:GenericRepository<Academicregulation>,IAcademicregulationRepository
    {
        public AcademicregulationRepository(CoreDbContext context):base(context)
        {

        }

        public async Task<Academicregulation> GetLatest(int programmeId, int AttendenceTypeId)
        {
            return await _context.academicregulations.Where(q => q.ProgrammeId == programmeId && q.AttendencetypeId == AttendenceTypeId && q.IsApproved == true && q.IsActive == true).OrderBy(q => q.Id).LastOrDefaultAsync();
        }
    }
}
