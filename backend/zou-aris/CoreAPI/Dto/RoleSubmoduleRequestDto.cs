using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class RoleSubmoduleRequestDto
    {
        public int Id { get; set; }
        public string RoleId { get; set; }

        public int RoleSystemmoduleId { get; set; }

        public int SystemSubmoduleId { get; set; }

        public string action { get; set; }
    }
}
