using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicationPayment:Auditable,IAuditable
    {
        public int Id { get; set; }

        public string uuid { get; set; }
        public int applicationId { get; set; }

        public int applicantId { get; set; }
        public int admissionsessionId { get; set; }

        public string? pollUrl { get; set; }

        public string currency { get; set; }

        public int amount { get; set; }

        public string status { get; set; } = string.Empty;

        public string? referencenumber { get; set; }=string.Empty;

        public string paymentmethod { get; set; } = string.Empty;

        public Application application { get; set; }

        public AdmissionSession admissionSession { get; set; }

        public Applicant applicant { get; set; }

        public string? administratorId { get; set; }


    }
}
