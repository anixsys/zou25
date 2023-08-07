using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Semesters
{
    public interface ISemesterRepository:IGenericRepository<Semester>
    {
        Task<Semester> GetLatest();
    }
}
