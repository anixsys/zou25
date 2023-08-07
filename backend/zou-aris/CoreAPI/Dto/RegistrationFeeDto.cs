namespace CoreAPI.Dto
{
    public class RegistrationFeeDto
    {
        public int? Id { get; set; }

        public int RegistrationFeeTemplateId { get; set; }

        public int FacultyId { get; set; }

        public int ApplicantTypeId { get; set; }

        public int ProgrammeTypeId { get; set; }

        public int CurrencyId { get; set; }

        public string Cost { get; set; }
    }
}
