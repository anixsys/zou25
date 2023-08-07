using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Programme : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public int ProgrammeTypeId { get; set; }
      

        public ProgrammeType? Type { get; set; }

        public int DepartmentId { get; set; }

        public string Status { get; set; }

        public Department? Department { get; set; }
        public List<ProgrammeSpecialization> Specializations { get; set; }
        public List<ProgrammeHistory> History { get; set; }
        public List<Admissionprogramme> Admissionprogrammes { get; set; }

        public ICollection<Academicregulation>? Academicregulations { get; set; }

    }
}
