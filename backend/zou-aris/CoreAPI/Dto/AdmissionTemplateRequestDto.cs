using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AdmissionTemplateRequestDto
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public int ProgrammetypeId { get; set; }

        public string? Status { get; set; }

    }
}
