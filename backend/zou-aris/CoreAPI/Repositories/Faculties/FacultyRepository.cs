using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Faculties
{
    public class FacultyRepository:GenericRepository<Faculty>,IFacultyRepository
    {
        public FacultyRepository(CoreDbContext context):base(context) { }
    }
}
