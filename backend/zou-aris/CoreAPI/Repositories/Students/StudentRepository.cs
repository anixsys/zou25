using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Students
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(CoreDbContext context) : base(context)
        {
        }

        public Task<List<Student>> Search(string needle)
        {
             return _context.students.Where(q=>q.FullName.ToLower().Contains(needle.ToLower()) || q.Pin.ToLower().Contains(needle.ToLower())).ToListAsync();
        }
    }
}
