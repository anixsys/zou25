using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class SystemModuleRequestDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
