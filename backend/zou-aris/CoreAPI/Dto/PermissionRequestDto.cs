using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class PermissionRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int SystemSubmoduleId { get; set; }
    }
}
