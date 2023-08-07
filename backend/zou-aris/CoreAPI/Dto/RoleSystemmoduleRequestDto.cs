using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class RoleSystemmoduleRequestDto
    {
        public int? Id { get; set; }

        [Required]
        public string RoleId { get; set; }

        [Required]
        public int SystemModuleId { get; set; }

        [Required]
        public string action { get; set; }
    }
}
