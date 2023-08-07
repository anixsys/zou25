namespace CoreAPI.Dto
{
    public class ExaminationPeriodDto
    {
        public int Id { get; set; }

        public int SemesterId { get; set; }

        public string Name { get; set; }


        public DateTime Startdate { get; set; }


        public DateTime Enddate { get; set; }
    }
}
