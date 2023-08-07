using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class CourseOnOffer:Auditable,IAuditable
    {

        [Key] 
        public int Id { get; set; }

        public int CourseOnOfferTemplateId { get; set; }

        public int ProgrammeId { get; set; }

        public int AttendenceTypeId { get; set; }

        public int Level { get; set; }

        public int Semester { get; set; }   

        public int CourseId { get; set; }  

        public Course course { get; set; }  
        

    }
}
