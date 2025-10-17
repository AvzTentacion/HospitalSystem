using HospitalSystem.Data;
using HospitalSystem.Models;
using HospitalSystem.Models.MedicalAidDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAidCompanyController : ControllerBase
    {
        private readonly HospitalDbContext dbcontext;

        public MedicalAidCompanyController(HospitalDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetAllMedicalAidCompanies")]
        public IActionResult GetAllMedicalAidCompany()
        {
            return Ok(dbcontext.MedicalAidCompanies);
        }

        [HttpPost]
        public IActionResult AddMedicalAidCompany(AddMedicalAidCompanyDto addMedicalAidCompanyDto)        
        {
            var newCompany = new MedicalAidCompany()
            {
                Name = addMedicalAidCompanyDto.Name
            };

            dbcontext.MedicalAidCompanies.Add(newCompany);
            dbcontext.SaveChanges();
            return Ok(newCompany);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetMedicalAidCompany(Guid id)
        {
            var medicalAid = dbcontext.MedicalAidCompanies.Find(id);

            if (medicalAid == null)
            {
                return NotFound();
            }

            return Ok(medicalAid);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateMedicalAidCompany(Guid id, UpdateMedicalAidCompanyDto updateMedicalAidCompanyDto)
        {
            var medicalAid = dbcontext.MedicalAidCompanies.Find(id);

            if (medicalAid == null)
            {
                return NotFound();
            }

            medicalAid.Name = updateMedicalAidCompanyDto.Name;
            dbcontext.SaveChanges();
            return Ok(medicalAid);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteMedicalAidCompany(Guid id)
        {
            var medicalAid = dbcontext.MedicalAidCompanies.Find(id);

            if (medicalAid == null)
            {
                return NotFound();
            }

            dbcontext.MedicalAidCompanies.Remove(medicalAid);
            dbcontext.SaveChanges();
            return Ok(medicalAid);
        }
    }
}