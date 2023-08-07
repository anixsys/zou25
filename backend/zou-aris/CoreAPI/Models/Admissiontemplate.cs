using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Admissiontemplate:Auditable,IAuditable
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int ProgrammetypeId { get; set; }

        public string? Status { get; set; }

        public ProgrammeType? programmeType { get; set; }

        public List<Admissionprogramme>? programmes { get; set; }
    }
}
