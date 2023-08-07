using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Applicant:Auditable,IAuditable
    {

        [Key]
        public int Id { get; set; }

        public string uuid { get; set; } 
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; }

        public string Surname { get; set; } = string.Empty;

        public string FullName { get; private set; } 

        public string Phonenumber { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string MaritalStatus { get; set; } = string.Empty;

        public string Maidenname { get; set; } = string.Empty;

        public string DOB { get; set; } = string.Empty;

        public string IdentificationType { get; set; } = string.Empty;
        public string identification { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public List<Application>? applications { get; set; }
        public List<ApplicantDocument>? documents { get; set; }

        public List<ApplicantSubject>? subjects { get; set; }

        public List<ApplicantOtherqualification>? otherqualifications { get; set; }

        public List<ApplicantWorkexperience>? workexperiences { get; set; }

        public  ApplicantStudentnumber? studentnumber { get; set; }
    }
}
