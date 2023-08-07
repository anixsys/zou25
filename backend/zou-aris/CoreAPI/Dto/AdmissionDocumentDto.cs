using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class AdmissionDocumentDto
    {
        public int? id { get; set; }

        [Required]
        public int ApplicantTypeId { get; set; }
        [Required]
        public int ProgrammetypeId { get; set; }
        [Required]
        public int DocumentId { get; set; }
        [Required]
        public string? Status { get; set; }
    }
}
