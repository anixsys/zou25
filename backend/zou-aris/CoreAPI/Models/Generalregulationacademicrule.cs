using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Generalregulationacademicrule:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int GeneralregulationId { get; set; }

        public int level { get; set; }

        public int semester { get; set; }

        public int? requiredlevel { get; set; }
        public int? requiredsemester { get; set; }

        public int corepercentage { get; set; }

        public int? electivepercentage { get; set; }

        public Generalregulation? generalregulation { get; set; }
    }
}
