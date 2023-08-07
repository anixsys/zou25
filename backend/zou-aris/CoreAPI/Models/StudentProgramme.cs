using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class StudentProgramme:Auditable,IAuditable
    {
        [Key] 
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ProgrammeId { get; set; }

        public int AttendenceTypeId { get; set; }

        public int AcademicRegulationId { get; set; }

        public string Status { get; set; }

        public Student student { get; set; }

        public Programme programme { get; set; }

        public Academicregulation academicregulation { get; set; }

        public AttendenceType attendencetype { get; set; }

    }
}
