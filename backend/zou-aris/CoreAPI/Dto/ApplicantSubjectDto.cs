using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class ApplicantSubjectDto
    {
        public int? Id { get; set; }

        public int applicantId { get; set; }

        public int SubjectId { get; set; }

        public string level { get; set; }

        public string grade { get; set; }
    }
}
