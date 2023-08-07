using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AdmissionattendencetypeRequestDto
    {
        public int? Id { get; set; }

        public int AdmissionprogrammeId { get; set; }

        public int AttendencetypeId { get; set; }
    }
}
