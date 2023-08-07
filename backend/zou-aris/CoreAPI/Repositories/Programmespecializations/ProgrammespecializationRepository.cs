using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Programmespecializations
{
    public class ProgrammespecializationRepository : GenericRepository<ProgrammeSpecialization>, IProgrammeSpecializationRepository
    {
        public ProgrammespecializationRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
