using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Application:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }
        public int applicantId { get; set; }

        public string uuid { get; set; } 

        public string AppNumber { get; set; }

        public int AdmissionSessionId { get; set; }

        public int ApplicanttypeId { get; set; }

        public int CampusId { get; set; }

        public int ProgrammeTypeId { get; set; }

        public string? PaymentStatus { get; set; }

        public string? ApprovalStatus { get; set; }

        public string? ApplicationUserId { get; set; }

        public string? DocumentVerification { get; set; }

        public int attendencetypeId { get; set; }

        public string? UserId { get; set; }

        public int EntryModeId { get; set; }

        public string? Pushed { get; set; }

        public Applicant applicant { get; set; }

        public Applicanttype applicanttype { get; set; }

        public AttendenceType attendenceType { get; set; }

        public Campus Campus { get; set; }

        public ProgrammeType programmeType { get; set; }


        public User? user { get; set; }

        public AdmissionSession? admissionSession { get; set; } 

        public List<ApplicationProgramme>? applicationprogrammes { get; set; }
        public List<ApplicationEntryModeDocument> applicationentrymodes { get; set; }

        public  EntryMode entrymode { get; set; }
    }
}
