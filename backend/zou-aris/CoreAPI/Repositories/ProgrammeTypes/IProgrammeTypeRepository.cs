using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.ProgrammeTypes
{
    public interface IProgrammeTypeRepository:IGenericRepository<ProgrammeType>
    {
    }
}
