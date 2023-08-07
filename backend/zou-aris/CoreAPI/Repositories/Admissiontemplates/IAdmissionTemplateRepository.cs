using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Admissiontemplates
{
    public interface IAdmissionTemplateRepository:IGenericRepository<Admissiontemplate>
    {
    }
}
