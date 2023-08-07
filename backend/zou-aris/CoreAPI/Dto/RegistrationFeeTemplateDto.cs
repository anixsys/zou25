using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class RegistrationFeeTemplateDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

    }
}
