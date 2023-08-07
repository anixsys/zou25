using CoreAPI.Interface;
using Microsoft.AspNetCore.Identity;

namespace CoreAPI.Models
{
    public class User:IdentityUser,IAuditable
    {
        public string Name { get; set; }

        public string Title { get; set; }
        public string Surname { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Gender { get; set; }  

        public DateTime? PasswordExpiry { get; set; }

        public List<UserCampus> campuses{ get; set; }
        public List<UserDepartment> departments { get; set; }

    }
}
