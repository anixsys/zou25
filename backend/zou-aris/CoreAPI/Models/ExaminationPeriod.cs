using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class ExaminationPeriod:Auditable,IAuditable
    {
        [Key] 
        public int Id { get; set; }

        public int SemesterId { get; set; }

        public string Name { get; set; }


        public DateTime Startdate { get; set; }


        public DateTime Enddate { get; set; }

        public string InitiatedBy { get; set; }

        public string? ApprovedBy { get; set; }

        public string Status { get; set; }
    }
}
