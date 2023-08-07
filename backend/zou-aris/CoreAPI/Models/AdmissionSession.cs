using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.Interface;

namespace CoreAPI.Models
{
    public class AdmissionSession : Auditable, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Year { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public bool IsPublished { get; set; }

        public List<Admissionsessiontemplate>? Admissionsessiontemplate { get; set; }

        public List<Application> applications { get; set; }





    }
}
