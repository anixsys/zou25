using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.UserCampuses
{
    public interface IUserCampusRepository:IGenericRepository<UserCampus>
    {
    }
}
