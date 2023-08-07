using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ProgrammeImportDto
    {
       
        public string NewCode { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string ProgrammeType { get; set; } = string.Empty;
    }
}
