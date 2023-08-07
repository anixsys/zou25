using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class StudentKin:Auditable,IAuditable
    {
        [Key] 
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Email { get; set; }  

        public string? phonenumber { get; set; }

        public string? Address { get; set; }

    }
}
