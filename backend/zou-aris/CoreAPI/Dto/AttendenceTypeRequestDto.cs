using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class AttendenceTypeRequestDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
