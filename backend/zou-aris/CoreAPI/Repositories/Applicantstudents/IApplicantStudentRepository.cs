using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicantstudents
{
    public interface IApplicantStudentRepository:IGenericRepository<ApplicantStudentnumber>
    {
    }
}
