using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class RegistrationFee:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int RegistrationFeeTemplateId { get; set; }

        public int FacultyId { get; set; }

        public int ApplicantTypeId   { get; set; }

        public int ProgrammeTypeId { get; set; }

        public int CurrencyId { get; set; }

        public string Cost { get; set; }


      
        public Currency currency { get; set; }

        public Faculty faculty { get; set; }

        public Applicanttype? applicanttype { get; set; }

        public ProgrammeType? programmetype { get; set; }
        public RegistrationFeeTemplate template { get; set; }
    }
}
