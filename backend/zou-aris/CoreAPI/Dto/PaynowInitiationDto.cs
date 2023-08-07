using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class PaynowInitiationDto
    {
      
            public bool status { get; set; }

            public string url { get; set; } = string.Empty;

            public string? link { get; set; }

            public string message { get; set; } = string.Empty;
        
    }
}
