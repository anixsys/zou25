using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class DistrictDto
    {
        public int? Id { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
