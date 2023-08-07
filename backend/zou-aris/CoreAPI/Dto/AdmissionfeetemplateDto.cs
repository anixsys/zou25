using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AdmissionfeetemplateDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public string? Status { get; set; }
    }
}
