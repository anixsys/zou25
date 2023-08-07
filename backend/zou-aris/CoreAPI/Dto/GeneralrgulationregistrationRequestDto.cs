using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class GeneralrgulationregistrationRequestDto
    {
        public int? Id { get; set; }

        [Required]
        public int GeneralregulationId { get; set; }

        [Required]
        public int maximumcourses { get; set; }
    }
}
