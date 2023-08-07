using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Academicregulation:Auditable,IAuditable
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ProgrammeId { get; set; }
        public int AttendencetypeId { get; set; }
        public AttendenceType? Attendencetype { get; set; }

        public int ProgrammeTypeId { get; set; }

        public bool? IsApproved { get; set; }

        public bool? IsActive { get; set; }

        public int? GeneralregulationId { get; set; }

        public int Duration { get; set; }

        public int? MaximumYears { get; set; }

        public int Year { get; set; }

        public Programme? Programme { get; set; }

        public ProgrammeType? ProgrammeType { get; set; }

        public List<Academicregulationparameter> Parameters { get; set; }
    }
}
