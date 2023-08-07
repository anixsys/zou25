using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
   public class GeneralregulationacademicruleRequestDto
    {
        public int Id { get; set; }

        public int GeneralregulationId { get; set; }

        public int level { get; set; }

        public int semester { get; set; }

        public int? requiredlevel { get; set; }
        public int? requiredsemester { get; set; }

        public int corepercentage { get; set; }

        public int? electivepercentage { get; set; }
    }
}
