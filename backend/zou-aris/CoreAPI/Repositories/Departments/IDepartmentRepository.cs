using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Departments
{
   public interface IDepartmentRepository:IGenericRepository<Department>
    {
        
    }
}
