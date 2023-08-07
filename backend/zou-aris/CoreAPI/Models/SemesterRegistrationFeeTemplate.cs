using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class SemesterRegistrationFeeTemplate:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; } 

        public int RegistrationFeeTemplateId { get; set; }

        public int SemesterId { get; set; }

        public RegistrationFeeTemplate registrationFeeTemplate { get; set; }
    }
}
