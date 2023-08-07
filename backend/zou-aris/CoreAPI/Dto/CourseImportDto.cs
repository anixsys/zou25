using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class CourseImportDto
    {
        public string DepartmentName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
