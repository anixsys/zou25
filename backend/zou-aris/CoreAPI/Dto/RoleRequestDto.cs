using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class RoleRequestDto
    {
       
        public string? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public string View { get; set; }
    }
}
