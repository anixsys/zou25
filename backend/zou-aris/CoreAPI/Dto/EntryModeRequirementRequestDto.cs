using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class EntryModeRequirementRequestDto
    {
        public int Id { get; set; }

        public int EntryModeId { get; set; }

        public string Name { get; set; }
    }
}
