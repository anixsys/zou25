using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class FacultyRequestDto
    {
        public int? Id{ get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
        public string Type { get; set; }
    }
}
