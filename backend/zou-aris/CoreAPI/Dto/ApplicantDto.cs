using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ApplicantDto
    {
        public int? Id { get; set; } 
        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string Phonenumber { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string MaritalStatus { get; set; } = string.Empty;

        public string? Maidenname { get; set; } = string.Empty;

        [Required]
        public string DOB { get; set; } = string.Empty;

        public string? IdentificationType { get; set; } = string.Empty;

        public string? identification { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        public string uuid { get; set; } = string.Empty;
    }
}
