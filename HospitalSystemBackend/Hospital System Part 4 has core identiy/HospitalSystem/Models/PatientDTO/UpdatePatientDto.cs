namespace HospitalSystem.Models.PatientDTO
{
    public class UpdatePatientDto
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Username { get; set; }

        public required string HomeAddress { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required bool MedicalAid { get; set; }

       
    }
}
