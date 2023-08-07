using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Courses
{
    public class CourseRepository:GenericRepository<Course>,ICourseRepository
    {
        public CourseRepository(CoreDbContext context):base(context)
        {

        }
    }
}
