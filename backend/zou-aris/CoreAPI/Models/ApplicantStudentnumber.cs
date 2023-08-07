using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicantStudentnumber:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }
        public int applicantId { get; set; }

        public int? applicationId { get; set; }

        public int? AdmissionSessionId { get; set; }

        public string nationalId { get; set; }
        public string studentnumber { get; set; }

        public string? DocVerified { get; set; }

        public string? UserId { get; set; }

        public Applicant applicant { get; set; }

        public Application application { get; set; } 
        public AdmissionSession admissionSession { get; set; }

        public User user { get; set; }
    }
}
