using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class SystemsubmoduleRequestDto
    {
        public int? Id { get; set; }

        [Required]
        public int SystemModuleId { get; set; }

        [Required]
        public string Icon { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
