using System.ComponentModel.DataAnnotations;

namespace CoreAPI.Dto
{
    public class ApplicantImportDto
    {
        public string  name { get; set; }

        public string email { get; set; }

        public string surname { get; set; }

        public string phone_number { get; set; }

        public string title { get; set; }

        public string maritalstatus { get; set; }
        public string maiden_name { get; set; }

        public string dob { get; set; }

        public string identification { get; set; }

        public string identification_type { get; set; }

        public string  gender { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? country { get; set; }    

        public string application_number { get; set; }

        public string campus { get; set; }

        public string programme_code { get; set; }
    }
}
