using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Applicationpayments
{
    public class ApplicationPaymentRepository:GenericRepository<ApplicationPayment>,IApplicationPaymentRepository
    {
        public ApplicationPaymentRepository(CoreDbContext context):base(context)
        {

        }
    }
}
