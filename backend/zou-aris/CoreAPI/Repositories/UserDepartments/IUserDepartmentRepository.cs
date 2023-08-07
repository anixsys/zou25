using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.UserDepartments
{
    public interface IUserDepartmentRepository:IGenericRepository<UserDepartment>
    {
    }
}
