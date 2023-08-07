using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.ProgrammeTypes
{
    public class ProgrammeTypeRepository:GenericRepository<ProgrammeType>,IProgrammeTypeRepository
    {
        public ProgrammeTypeRepository(CoreDbContext context):base(context) { }
    }
}
