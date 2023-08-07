using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Users
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(CoreDbContext context):base(context) { }

       
    }
}
