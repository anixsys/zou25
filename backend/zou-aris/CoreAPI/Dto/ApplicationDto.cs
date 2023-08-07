using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ApplicationDto
    {
        public int? Id { get; set; }

        public int ApplicantId { get; set; }

        public int AdmissionSessionId { get; set; }

        public int ApplicanttypeId { get; set; }

        public int CampusId { get; set; }

        public int ProgrammeTypeId { get; set; }

        public int AttendenceTypeId { get; set; }
        public string? PaymentStatus { get; set; }

        public string? ApprovalStatus { get; set; }

        public int EntryModeId { get; set; }
    }
}
