using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class Semester:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Uuid { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Status { get; set; }  

        public string InitiatedBy { get; set; }

        public string? ApprovedBy { get; set; }

       

        public List<RegistrationPeriod> registrationperiods { get; set; }   

        public List<SemesterRegistrationFeeTemplate> semesterregistrationfees { get; set; }

        public List<ExaminationPeriod> examinationperiods { get; set;}


    }
}
