using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class RoleviewDto
    {
        public string Name { get; set; }
        public string View { get; set; }

        public List<MainmenuDto>? mainmenu { get; set; }
    }
}
