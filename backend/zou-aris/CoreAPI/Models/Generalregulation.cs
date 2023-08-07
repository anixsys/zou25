using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Generalregulation:Auditable,IAuditable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Year { get; set; }

        public int ProgrammetypeId { get; set; }

        public string Status { get; set; } = string.Empty;

        public int GlobalsettingtemplateId { get; set; }

        public Globalsettingtemplate? globalsettingtemplate { get; set; }

        public ProgrammeType? programmeType { get; set; }

        public List<Generalregulationacademicrule>? generalregulationacademicrules { get; set; }

        public List<Generalregulationregistrationrule>? generalregulationregistrationrules { get; set; }
    }
}
