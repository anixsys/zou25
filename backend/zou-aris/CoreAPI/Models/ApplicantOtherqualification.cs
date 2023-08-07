using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicantOtherqualification:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int applicantId { get; set; }

        public string institution { get; set; }

        public string qualification { get; set; }

        public string year { get; set; }

        public string grade { get; set; }

        public Applicant? applicant { get; set; }
    }
}
