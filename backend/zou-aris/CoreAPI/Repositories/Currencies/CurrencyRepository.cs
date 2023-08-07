using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;

namespace CoreAPI.Repositories.Currencies
{
    public class CurrencyRepository:GenericRepository<Currency>,ICurrencyRepository
    {
        public CurrencyRepository(CoreDbContext context):base(context)
        {

        }
    }
}
