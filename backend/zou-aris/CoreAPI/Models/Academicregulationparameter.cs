using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class Academicregulationparameter:Auditable,IAuditable
    {
        public int Id { get; set; }

        public int AcademicRegulationId { get; set; }

        public int level { get; set; }

        public int semester { get; set; }

        public int CourseId { get; set; }

        public string CourseType { get; set; } = string.Empty;

        public int ExamContribution { get; set; }

        public int CourseworkContribution { get; set; }

        public int CourseWeight { get; set; }

        public int CourseTake { get; set; }


        public  Academicregulation? Regulation { get; set; } 

        public Course? Course { get; set; }

        public List<Prerequisite> Prerequisites { get; set; }   

        public List<Alternative> Alternatives { get; set;}



    }
}
