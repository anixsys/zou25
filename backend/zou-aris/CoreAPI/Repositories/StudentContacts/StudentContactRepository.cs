using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.StudentContacts
{
    public class StudentContactRepository : GenericRepository<StudentContact>, IStudentContactRepository
    {
        public StudentContactRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
