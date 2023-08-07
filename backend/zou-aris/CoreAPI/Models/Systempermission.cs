using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreAPI.Interface;

namespace CoreAPI.Models
{
    public class Systempermission:Auditable,IAuditable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int SystemSubmoduleId { get; set; }

        public Systemsubmodule? systemsubmodule { get; set; }

        public List<RoleSystempermission>? rolepermissions { get; set; }
    }
}
