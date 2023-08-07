using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class GlobalsettingRequestDto
    {
        public int Id { get; set; }

        [Required]
        public string? description { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string? decisiontype { get; set; }

        [Required]
        public int? semesters { get; set; }
    }
}
