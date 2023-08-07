using CoreAPI.Interface;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Models
{
    public class SemesterCourse:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int SemesteId { get; set;}

        public int  CourseOnOfferTemplateId { get; set; }

        public CourseOnOfferTemplate CourseOnOfferTemplate { get; set; }
    }
}
