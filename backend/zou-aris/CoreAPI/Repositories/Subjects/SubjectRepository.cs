using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Subjects
{
    public class SubjectRepository:GenericRepository<Subject>,ISubjectRepository
    {
        public SubjectRepository(CoreDbContext context):base(context)
        {

        }
    }
}
