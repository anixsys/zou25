using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Ecnumber { get; set; }
        public string? Email { get; set; }

        public string? Status { get; set; }

        public int DepartmentId { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Phonenumber { get; set; } = string.Empty;

    }
}
