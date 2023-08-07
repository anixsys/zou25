using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Faculties
{
    public interface IFacultyRepository:IGenericRepository<Faculty>
    {
    }
}
