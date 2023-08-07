using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class DepartmentDto
    {
        public int? Id { get; set; }

        public int? FacultyId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
