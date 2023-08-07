using CoreAPI.Dto;
using CoreAPI.Models;

namespace CoreAPI.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(AdminAuthDto dto);
        Task<ResponseDto> ChangePassword(ChangePasswordDto dto);

        Task<ProfileReponse> GetProfileAsync();
        Task<IList<MainmenuDto>> GetMainMenu(string role);
        Task<ProfileReponse> FormateProfile(User user, IList<string> roles);

        IList<MainmenuDto> GenerateMainmenu(Role role);

        Task<User> GetCurrentUser();

    }
}
