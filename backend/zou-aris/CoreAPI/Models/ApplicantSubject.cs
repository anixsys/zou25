using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicantSubject:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int applicantId { get; set; }

        public int SubjectId { get; set; }

        public string level { get; set; }

        public string grade { get; set; }

        public Applicant? applicant { get; set; }

        public Subject subject { get; set; }
    }
}
