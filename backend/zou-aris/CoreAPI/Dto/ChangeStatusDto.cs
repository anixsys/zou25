using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ChangeStatusDto
    {
        public int Id { get; set; }

        public string Status { get; set; }  
    }
}
