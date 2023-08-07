using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Prerequisites
{
    public interface IPrerequisiteRepository:IGenericRepository<Prerequisite>
    {
    }
}
