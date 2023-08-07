using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AcademicregulationparameterDto
    {
        public int? Id { get; set; }

        [Required]
        public int AcademicRegulationId { get; set; }

        [Required]
        public int level { get; set; }

        [Required]
        public int semester { get; set; }

        [Required]
        public int CourseId { get; set; }
        [Required]
        public string CourseType { get; set; } = string.Empty;

        [Required]
        public int ExamContribution { get; set; }

        [Required]
        public int CourseworkContribution { get; set; }

        [Required]
        public int CourseWeight { get; set; }

        [Required]
        public int CourseTake { get; set; }
    }
}
