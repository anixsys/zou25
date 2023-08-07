using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Faculty:Auditable,IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public string Type { get; set; }
        public List<Department> Departments { get; set; }
    }
}
