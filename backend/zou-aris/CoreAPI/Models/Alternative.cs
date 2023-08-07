using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Alternative : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }   
        public int AcademicregulationparameterId { get; set; }
     
        public int CourseId { get; set; }

        public Course course { get; set; }
    }
}
