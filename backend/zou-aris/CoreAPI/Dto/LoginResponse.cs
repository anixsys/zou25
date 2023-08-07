using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class LoginResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;
        public bool status { get; set; }

        public string message { get; set; }

        public DateTime Expiration { get; set; }
    }
}
