using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ApplicantTypeDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
