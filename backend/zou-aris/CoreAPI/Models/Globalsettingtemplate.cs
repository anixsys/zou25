using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Globalsettingtemplate:Auditable,IAuditable
    {
        public int Id { get; set; }

        public string? description { get; set; }

        public int Year { get; set; }
        public string? decisiontype { get; set; }

        public int? semesters { get; set; }

        public List<Generalregulation> generalregulations { get; set; }
    }
}
