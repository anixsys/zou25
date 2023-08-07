using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class RoleSystemmodule:Auditable,IAuditable
    {
        [Key]

        public int Id { get; set; }

        public string RoleId { get; set; }

        public int SystemModuleId { get; set; }

        public  Systemmodule systemmodule { get; set; }

        public List<RoleSystemsubmodule> submodules { get; set; }

    }
}
