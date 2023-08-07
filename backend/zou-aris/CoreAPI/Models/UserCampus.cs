using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class UserCampus : Auditable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]

        public int CampusId { get; set; }

        public User user { get; set; }

        public Campus campus { get; set; }
    }
}
