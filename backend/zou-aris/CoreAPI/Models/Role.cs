using CoreAPI.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Role: IdentityRole, IAuditable
    {
          
        public string View { get; set; } = string.Empty;
        public List<RoleSystemmodule>? systemmodules { get; set; }

        public List<RoleSystempermission> systempermissions { get;set; }
    }
}
