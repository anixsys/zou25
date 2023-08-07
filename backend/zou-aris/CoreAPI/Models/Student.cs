using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAPI.Models
{
    public class Student:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Pin { get; set; }

        public string? Title { get; set; }

        public string? Gender { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Identificationtype { get; set; }

        public string? Identificationnumber { get; set; }

       
        public string FullName { get; private set; }



        public string Email { get; set; }


        public string? Profile { get; set; }

        public string Dob { get; set; } 

        public int? CampusId { get; set; }

        public string? Intake { get; set; }

        public string? Pushed { get; set;}

        public StudentKin nextofkin { get; set; } 

        public List<StudentProgramme> programmes { get; set; }

        public StudentContact contact { get; set; }

        public Campus campus { get; set; }  

    }
}
