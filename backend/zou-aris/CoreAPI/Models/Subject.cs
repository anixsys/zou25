using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Subject : Auditable, IAuditable
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
    }
}
