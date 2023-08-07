using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Tokeninfos
{
    public class TokenInfoRepository:GenericRepository<TokenInfo>,ITokenInfoRepository
    {
        public TokenInfoRepository(CoreDbContext context):base(context) { }

        public async Task<TokenInfo> GetByUsernameAsync(string username)
        {
            return await _context.tokeninfo.OrderByDescending(q => q.Id).LastOrDefaultAsync(q => q.Username == username);
        }
    }
}
