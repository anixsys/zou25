using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AcademicregulationRequestDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int ProgrammeId { get; set; }

        [Required]
        public int AttendencetypeId { get; set; }

        [Required]
        public int ProgrammeTypeId { get; set; }

        [Required]
        public int? GeneralregulationId { get; set; }

        [Required]
        public int? Duration { get; set; }

        [Required]
        public int? MaximumYears { get; set; }

        [Required]

        public int? Year { get; set; }
    }
}
