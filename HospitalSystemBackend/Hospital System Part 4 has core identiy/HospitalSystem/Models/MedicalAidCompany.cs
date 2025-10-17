namespace HospitalSystem.Models
{
    public class MedicalAidCompany
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Patient>? Patients { get; set; }
    }
}
