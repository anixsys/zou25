using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class CourseRequestDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public int DepartmentId { get; set; }
    }
}
