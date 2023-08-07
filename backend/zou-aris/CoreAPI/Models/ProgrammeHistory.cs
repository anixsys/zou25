using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public  class ProgrammeHistory:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int ProgrammeId { get; set; }

        public string Code { get; set; }
    }
}
