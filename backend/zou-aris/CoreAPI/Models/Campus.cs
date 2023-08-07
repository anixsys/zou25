using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CoreAPI.Interface;

namespace CoreAPI.Models
{
    public class Campus : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;


        [Required]
        public string Address { get; set; } = string.Empty;


        public int CampusTypeId { get; set; }

        public int DistrictId { get; set; }

        public string Status { get; set; } = string.Empty;

        public CampusType? CampusType { get; set; }

        public District? District { get; set; }
        public ICollection<UserCampus>? users { get; set; }

        public List<Application> applications { get; set; }


     


    }
}
