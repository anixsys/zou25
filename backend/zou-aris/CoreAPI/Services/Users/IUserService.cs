using CoreAPI.Dto;
using CoreAPI.Models;

namespace CoreAPI.Services.Users
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<Object> GetUserRoles(string id);
        Task<ResponseDto> CreateUser(AdministratorRequestDto dto, string password);
        Task<Object> GetAdministrator(string id);
        Task<ResponseDto> UpdateUser(AdministratorRequestDto updateAdminDto);
        Task<ResponseDto> DeleteUser(string id);
        Task<ResponseDto> ChangeRole(string id, string roles);
        Task<ResponseDto> ResetPassword(string id);
    }
}
