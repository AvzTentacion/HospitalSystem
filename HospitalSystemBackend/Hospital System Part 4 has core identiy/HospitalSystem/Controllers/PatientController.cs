using HospitalSystem.Data;
using HospitalSystem.Models;
using HospitalSystem.Models.PatientDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalDbContext dbcontext;

        public PatientController(HospitalDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllPatient()
        {
            return Ok(dbcontext.Patients);
        }

        [HttpPost]
        public IActionResult AddPatient(AddPatientDto addPatientDto)
        {
            var newPatient = new Patient()
            {
                Name = addPatientDto.Name,
                Surname = addPatientDto.Surname,
                Username = addPatientDto.Username,
                HomeAddress = addPatientDto.HomeAddress,
                Email = addPatientDto.Email,
                Phone = addPatientDto.Phone,
                MedicalAid = addPatientDto.MedicalAid
                
            };

            dbcontext.Patients.Add(newPatient);
            dbcontext.SaveChanges();
            return Ok(newPatient);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetPatient(Guid id)
        {
            var medicalAid = dbcontext.Patients.Find(id);

            if (medicalAid == null)
            {
                return NotFound();
            }

            return Ok(medicalAid);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdatePatient(Guid id, UpdatePatientDto updatePatientDto)
        {
            var medicalAid = dbcontext.Patients.Find(id);

            if (medicalAid == null)
            {
                return NotFound();
            }

            medicalAid.Name = updatePatientDto.Name;
            dbcontext.SaveChanges();
            return Ok(medicalAid);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeletePatient(Guid id)
        {
            var medicalAid = dbcontext.Patients.Find(id);

            if (medicalAid == null)
            {
                return NotFound();
            }

            dbcontext.Patients.Remove(medicalAid);
            dbcontext.SaveChanges();
            return Ok(medicalAid);
        }
    }
}
