using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.StudentKins
{
    public class StudentKinRepository : GenericRepository<StudentKin>, IStudentKinRepository
    {
        public StudentKinRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
