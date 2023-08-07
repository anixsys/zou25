using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class MainmenuDto
    {
        public string? Name { get; set; }

        public string? Icon { get; set; }
        public IList<SubmenuDto> submenues { get; set; }
    }
}
