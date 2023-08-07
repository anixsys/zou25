using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AdminAuthDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
