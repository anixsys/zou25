
using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Admissionattendencetype:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int AdmissionprogrammeId { get; set; }

        public int AttendencetypeId { get; set; }

        public AttendenceType attendencetype { get; set; }
    }
}
