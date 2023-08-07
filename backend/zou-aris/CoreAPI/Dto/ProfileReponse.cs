using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ProfileReponse
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Ecnumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public bool Passwordexpired { get; set; }   

        public IList<RoleviewDto>? Role { get; set; }
    }
}
