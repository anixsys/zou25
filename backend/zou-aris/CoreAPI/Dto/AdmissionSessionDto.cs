using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AdmissionSessionDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public string? StartDate { get; set; }
        [Required]
        public string? EndDate { get; set; }
        [Required]
        public bool IsPublished { get; set; }

        [Required]
        public string? templates { get; set; }
    }
}
