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
   public class AdmissionFee : Auditable, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public  int AdmissionFeeTemplateId { get; set; }

        public int ApplicanttypeId { get; set; }    

        public int ProgrammeTypeId { get; set; }       

        public int CurrencyId { get; set; } 

        public double amount { get; set; }

        public AdmissionFeeTemplate admissionFeeTemplate { get; set; }
        public Applicanttype? Applicanttype { get; set; }
        public Currency? Currency { get; set; }
        public ProgrammeType? programmeType { get; set; }
    }
}
