using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class GeneralregulationRequestDto
    {
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        public int? GlobalsettingtemplateId { get; set; }

        [Required]
        public int ProgrammetypeId { get; set; }


        public string? Status { get; set; }
    }
}
