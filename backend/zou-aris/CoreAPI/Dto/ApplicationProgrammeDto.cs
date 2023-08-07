using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ApplicationProgrammeDto
    {
        public int Id { get; set; }
        public int applicationId { get; set; }

        public int ProgrammeId { get; set; }

        public int AttendenceTypeId { get; set; }

        public string Status { get; set; }
    }
}
