using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Department:Auditable,IAuditable
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int FacultyId { get; set; }

        public Faculty Faculty { get;set; }

        public List<CourseOnOfferTemplate> CourseOnOfferTemplates { get; set; }

    }
}
