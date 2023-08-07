using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Currency : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<AdmissionFee> AdmissionFees { get; set; }


    }
}
