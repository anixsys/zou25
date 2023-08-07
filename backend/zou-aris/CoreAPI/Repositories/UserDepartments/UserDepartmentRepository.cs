using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.UserDepartments
{
    public class UserDepartmentRepository:GenericRepository<UserDepartment>,IUserDepartmentRepository
    {
        public UserDepartmentRepository(CoreDbContext context):base(context)
        {

        }
    }
}
