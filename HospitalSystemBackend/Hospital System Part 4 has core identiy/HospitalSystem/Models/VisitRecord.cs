namespace HospitalSystem.Models
{
    public class VisitRecord
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }

        //FKs
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }

        //Nav properties
        public User? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }
}
