using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Systemsubmodule:Auditable,IAuditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SystemModuleId { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public string  Url { get; set; }

        public Systemmodule? systemmodule { get; set; }  

        public List<Systempermission>? permissions { get; set; }

        public List<RoleSystemsubmodule>? rolesystemsubmodules { get; set; }
    }
}
