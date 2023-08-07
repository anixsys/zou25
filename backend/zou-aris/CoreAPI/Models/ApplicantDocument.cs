using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicantDocument:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int admissiondocumentId { get; set; }
        public int applicantId { get; set; }

        public string filename { get; set; }

        public string?  Verified { get; set; }

        public string? VerifiedBy { get; set; }

        public AdmissionDocument? admissionDocument { get; set; }

        public Applicant? applicant { get; set; }
    }
}
