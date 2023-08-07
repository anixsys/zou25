using CoreAPI.Data;
using CoreAPI.Models;
using CoreAPI.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Repositories.Tokeninfos
{
    public interface ITokenInfoRepository:IGenericRepository<TokenInfo>
    {
        Task<TokenInfo> GetByUsernameAsync(string username);
    }
}
