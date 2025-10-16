namespace HospitalSystem.Models.VisitRecordDTO
{
    public class VisitRecordDto
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }
    }
}
