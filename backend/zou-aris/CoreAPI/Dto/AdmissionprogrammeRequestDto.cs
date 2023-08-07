using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AdmissionprogrammeRequestDto
    {
        public int AdmissionTemplateId { get; set; }

        public string selectedprogrammes { get; set; }
    }
}
