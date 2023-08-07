using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class FacultyImport
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public string Type { get; set; }
    }
}
