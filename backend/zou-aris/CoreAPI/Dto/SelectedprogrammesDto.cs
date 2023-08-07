using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class SelectedprogrammesDto
    {
        public int id { get; set; }

        public List<AttendenceTypeRequestDto> attendencetypes { get; set; }
    }
}
