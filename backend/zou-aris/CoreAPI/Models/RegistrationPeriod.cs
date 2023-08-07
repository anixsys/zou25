using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class RegistrationPeriod:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }


        public string? Type { get; set; }    
        public int SemesterId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }  

        public int InitiatedBy { get; set; }

        public int? ApprovedBy { get; set; }
    }
}
