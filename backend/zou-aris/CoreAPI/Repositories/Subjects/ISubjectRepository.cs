using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Subjects { 
    public interface ISubjectRepository:IGenericRepository<Subject>
    {
    }
}
