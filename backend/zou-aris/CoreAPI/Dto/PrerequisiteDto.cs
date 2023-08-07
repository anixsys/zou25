using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class PrerequisiteDto
    {

        [Required]
        public int AcademicregulationparameterId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
