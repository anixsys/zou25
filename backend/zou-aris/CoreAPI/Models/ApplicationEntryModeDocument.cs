
using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class ApplicationEntryModeDocument:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }


        public int ApplicationId { get; set; }

        public int EntryModeRequirementId { get; set; }

        public string filename { get; set; }    

        public EntryModeRequirement modeRequirement { get; set; }
    }
}
