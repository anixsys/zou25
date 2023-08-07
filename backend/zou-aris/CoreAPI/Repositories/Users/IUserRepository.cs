using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Users
{
    public interface IUserRepository:IGenericRepository<User>
    {
     
    }
}
