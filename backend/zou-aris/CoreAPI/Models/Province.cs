using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Province:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<District>? Districts { get; set; }
    }
}
