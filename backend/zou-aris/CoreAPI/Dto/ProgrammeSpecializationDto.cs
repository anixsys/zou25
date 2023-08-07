using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ProgrammeSpecializationDto
    {

        public int? id { get; set; }
        public int ProgrammeId { get; set; }

        [Required]
        public string Area { get; set; }
    }
}
