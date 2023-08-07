using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Admissionattendencetypes
{
    public class AdmissionattendencetypeRepository : GenericRepository<Admissionattendencetype>, IAdmissionattendencetypeRepository
    {
        public AdmissionattendencetypeRepository(CoreDbContext context) : base(context)
        {
        }
    }
}
