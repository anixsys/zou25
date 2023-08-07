using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ProgrammeHistoryDto
    {
        public int? id { get; set; }

        public int ProgrammeId { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
