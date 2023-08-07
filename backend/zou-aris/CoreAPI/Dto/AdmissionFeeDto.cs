using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class AdmissionFeeDto
    {
        public int? Id { get; set; }

        [Required]
        public int AdmissionFeeTemplateId { get; set; }

        [Required]
        public int ApplicanttypeId { get; set; }

        [Required]
        public int ProgrammeTypeId { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public double amount { get; set; }
    }
}
