using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class UserDepartment:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string UserId {get;set;}

        public User user { get;set;}    

        public Department department { get; set; }
    }
}
