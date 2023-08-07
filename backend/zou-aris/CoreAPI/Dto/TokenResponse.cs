using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class TokenResponse
    {
        public string? Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
