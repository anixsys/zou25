using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class SubmenuDto
    {
        public string? Name { get; set; }

        public string? Url { get; set; }

        public string? Icon { get; set; }

        public List<PermissionDto> permissions { get; set; }

        
    }
}
