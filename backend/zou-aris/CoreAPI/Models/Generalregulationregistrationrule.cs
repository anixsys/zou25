using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Generalregulationregistrationrule:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int GeneralregulationId { get; set; }

        public int maximumcourses { get; set; }

        public Generalregulation generalregulation { get; set; }
    }
}
