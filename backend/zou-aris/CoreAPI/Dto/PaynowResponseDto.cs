using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class PaynowResponseDto
    {
        public bool status { get; set; }

        public string response { get; set; }

        public string message { get; set; }
    }
}
