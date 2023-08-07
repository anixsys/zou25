namespace CoreAPI.Dto
{
    public class RegistrationPeriodDto
    {
        public int? Id { get; set; }

        public int SemesterId { get; set; }

        public string Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
