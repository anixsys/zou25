using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissionprogrammes
{
    public interface IAdmissionprogrammeRepository:IGenericRepository<Admissionprogramme>
    {
    }
}
