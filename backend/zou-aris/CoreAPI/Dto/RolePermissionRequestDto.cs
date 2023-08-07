using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class RolePermissionRequestDto
    {
        public int Id { get; set; }

        public string RoleId { get; set; }

        public int RoleSystemSubmoduleId { get; set; }

        public int PermissionId { get; set; }

        public string action { get; set; }
    }
}
