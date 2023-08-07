using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class EntryModeRequirement:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int EntryModeId { get; set; }

        public EntryMode entrymode { get; set; }

        public List<ApplicationEntryModeDocument> applications { get; set; }
    }
}
