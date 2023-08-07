using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Admissionsessiontemplate:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int AdmissionSessionId { get; set; }

        public int AdmissionTemplateId { get; set; }
    }
}
