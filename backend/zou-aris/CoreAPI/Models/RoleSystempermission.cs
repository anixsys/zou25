using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace CoreAPI.Models
{
    public class RoleSystempermission:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string RoleId { get; set; }

        public int RoleSystemsubmoduleId { get; set; }

        public int SystempermissionId { get; set; }

        public Role role { get; set; }

        public RoleSystemsubmodule rolestystemsubmodule { get; set; }
        public Systempermission? permission { get; set; }
    }
}
