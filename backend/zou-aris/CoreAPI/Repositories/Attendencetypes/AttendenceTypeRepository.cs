using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Attendencetypes
{
    public class AttendenceTypeRepository:GenericRepository<AttendenceType>,IAttendenceTypeRepository
    {
        public AttendenceTypeRepository(CoreDbContext context):base(context)
        {

        }
    }
}
