using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class RegistrationFeeTemplate:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Uuid { get; set; }

        public int Year { get; set; }

        public string Status { get; set; }

        public string InitiatedBy { get; set; }

        public string? ApprovedBy { get; set; }

        public string? ChangeRequestId { get; set; }

        public List<RegistrationFee> registrationfees { get;}
    }
}
