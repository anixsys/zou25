using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class LoginRequestDto
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
