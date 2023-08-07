using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.StudentProgrammes
{
    public class StudentProgrammeRepository : GenericRepository<StudentProgramme>, IStudentProgrammeRepository
    {
        public StudentProgrammeRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
