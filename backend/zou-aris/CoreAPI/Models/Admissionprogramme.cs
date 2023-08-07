using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Admissionprogramme:Auditable,IAuditable
    {
        public int Id { get; set; }
        public int ProgrammeId { get; set; }
        public Programme? Programme { get; set; }
        public int AdmissionTemplateId { get; set; }

        public List<Admissionattendencetype> attendencetypes { get; set; }
    }
}
