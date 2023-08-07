using CoreAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class CourseOnOfferTemplate:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public string Status { get; set; }

        public int Inititateby { get; set; }

        public int? ApprovedBy { get; set;}

        public Department department { get; set; }

        public List<CourseOnOffer> courses { get; set; }
    }
}
