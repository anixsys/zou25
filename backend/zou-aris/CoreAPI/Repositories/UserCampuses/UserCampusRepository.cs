using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.UserCampuses
{
    public class UserCampusRepository:GenericRepository<UserCampus>,IUserCampusRepository
    {
        public UserCampusRepository(CoreDbContext context):base(context) { }
     
    }
}
