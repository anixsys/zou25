using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class RoleSystemsubmodule:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }
        public string RoleId { get; set; }

        public int RoleSystemmoduleId { get; set; }

        public int SystemSubmoduleId { get; set; }

        public Systemsubmodule systemsubmodule { get; set; }

        public  RoleSystemmodule rolesystemmodule { get; set; }

        public  List<RoleSystempermission>? Rolesystempermissions { get; set; }



    }
}
