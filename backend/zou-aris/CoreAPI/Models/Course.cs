using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Course:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Code { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public List<Academicregulationparameter>? Academicregulationparameters { get; set; }

    }
}
