using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public  class ChangePasswordDto
    {

        [Required]
        public string OldPassword { get; set; } = string.Empty;
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
