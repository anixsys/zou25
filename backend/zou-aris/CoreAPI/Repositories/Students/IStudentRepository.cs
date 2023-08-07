using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Students
{
    public interface IStudentRepository:IGenericRepository<Student>
    {

        Task<List<Student>> Search(string needle);
    }
}
