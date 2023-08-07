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
    public class District : Auditable, IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        public string Name { get; set; } = string.Empty;

        public int ProvinceId { get; set; }

        public Province? Province { get; set; }

        public virtual ICollection<Campus>? Campuses { get; set; }
    }
}
