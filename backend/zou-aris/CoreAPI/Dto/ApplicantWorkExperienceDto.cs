using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ApplicantWorkExperienceDto
    {
        public int? Id { get; set; }
        public int applicantId { get; set; }

        public string Company { get; set; }

        public string Jobtitle { get; set; }

        public string duration { get; set; }

    }
}
