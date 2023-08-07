using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class AdministratorRequestDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]

        public string Email { get; set; } = string.Empty;

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;


        [Required]
        public string Title { get; set; } = string.Empty;


        [Required]
        public string Gender { get; set; } = string.Empty;

        public string? Status { get; set; }


    }
}
