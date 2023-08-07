using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class UserRequestDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
