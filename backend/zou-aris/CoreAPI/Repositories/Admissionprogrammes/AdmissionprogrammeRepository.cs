using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissionprogrammes
{
    public class AdmissionprogrammeRepository:GenericRepository<Admissionprogramme>,IAdmissionprogrammeRepository
    {
        public AdmissionprogrammeRepository(CoreDbContext context):base(context) { }
        
    }
}
