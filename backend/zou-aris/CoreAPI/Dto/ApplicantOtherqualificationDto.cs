using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class ApplicantOtherqualificationDto
    {
        public int? Id { get; set; }

        public int applicantId { get; set; }

        public string institution { get; set; }

        public string qualification { get; set; }

        public string year { get; set; }

        public string grade { get; set; }
    }
}
