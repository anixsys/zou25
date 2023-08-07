using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicationprogrammes
{
   public interface IApplicationProgrammeRepository:IGenericRepository<ApplicationProgramme>
    {
    }
}
