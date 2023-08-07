using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Prerequisite:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int AcademicregulationparameterId { get; set; }  

        public int CourseId { get; set; }

        public Course course { get; set; }
    }
}
