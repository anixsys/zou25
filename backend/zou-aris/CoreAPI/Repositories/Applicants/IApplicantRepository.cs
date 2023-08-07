using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicants
{
    public interface IApplicantRepository:IGenericRepository<Applicant>
    {
    }
}
