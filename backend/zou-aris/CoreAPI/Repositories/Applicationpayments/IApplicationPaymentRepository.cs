using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicationpayments
{
    public interface IApplicationPaymentRepository:IGenericRepository<ApplicationPayment>
    {
    }
}
