using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Systemmodule:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public List<Systemsubmodule>? submodules { get; set; }

        public  List<RoleSystemmodule>? rolesystemmodules { get; set; }
    }
}
