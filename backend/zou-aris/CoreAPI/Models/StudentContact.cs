using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class StudentContact:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }  

        public string Phone { get;set; }

        public string Address { get; set; }
    }
}
