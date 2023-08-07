using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Academicregulations
{
    public interface IAcademicregulationRepository : IGenericRepository<Academicregulation>
    {
        Task<Academicregulation> GetLatest(int programmeId, int AttendenceTypeId);
    }
}
