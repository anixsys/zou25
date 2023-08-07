using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ProgrammeRequestDto
    {
        public int? Id { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int ProgrammeTypeId { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public string? Status { get; set; }
    }
}
