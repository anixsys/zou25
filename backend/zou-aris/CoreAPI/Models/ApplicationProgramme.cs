using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicationProgramme:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int applicationId { get; set; }

        public int ProgrammeId { get; set; }

        public int AttendenceTypeId { get; set; }

        public string Status { get; set; } = string.Empty;

        public Programme programme { get; set; }

        public Application application { get; set; }

        public AttendenceType attendenceType { get; set; }
    }
}
