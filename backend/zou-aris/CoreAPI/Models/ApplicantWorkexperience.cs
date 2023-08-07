using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicantWorkexperience:Auditable,IAuditable
    {
        public int Id { get; set; }
        public int applicantId { get; set; }

        public string Company { get; set; }

        public string Jobtitle { get; set; }

        public string duration { get; set; }

        public Applicant? applicant { get; set; }
    }
}
