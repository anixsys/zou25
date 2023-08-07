using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Programmes
{
    public interface IProgrammeRepository:IGenericRepository<Programme>
    {

        Task<List<Programme>> GetByAdmissionTemplate(int id);
    }
}
