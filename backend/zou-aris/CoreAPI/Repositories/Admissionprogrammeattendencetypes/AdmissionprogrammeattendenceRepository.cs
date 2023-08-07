using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissionprogrammeattendencetypes
{
    public class AdmissionprogrammeattendenceRepository:GenericRepository<Admissionattendencetype>,IAdmissionprogrammeattendencetypeRepository
    {
        public AdmissionprogrammeattendenceRepository(CoreDbContext context):base(context)
        {

        }
    }
}
