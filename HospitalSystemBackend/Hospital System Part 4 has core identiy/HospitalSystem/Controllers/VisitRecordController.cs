using HospitalSystem.Data;
using HospitalSystem.Models;
using HospitalSystem.Models.VisitRecordDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitRecordController : ControllerBase
    {
        private readonly HospitalDbContext dbcontext;

        public VisitRecordController(HospitalDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllRecords()
        {
            return Ok(dbcontext.VisitRecords);
        }

        [HttpPost]
        public IActionResult AddVisitRecord(VisitRecordDto addVisitRecordDto)
        {
            var newRecord = new VisitRecord()
            {
                Date = addVisitRecordDto.Date,
                Diagnosis = addVisitRecordDto.Diagnosis,
                Treatment = addVisitRecordDto.Treatment
            };

            dbcontext.VisitRecords.Add(newRecord);
            dbcontext.SaveChanges();
            return Ok(newRecord);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetVisitRecord(Guid id)
        {
            var wantedRecord = dbcontext.VisitRecords.Find(id);

            if (wantedRecord == null)
            {
                return NotFound();
            }

            return Ok(wantedRecord);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateVisitRecord(Guid id, UpdateVisitRecordDto updateVisitRecordDto)
        {
            var UpdatedRecord = dbcontext.VisitRecords.Find(id);

            if (UpdatedRecord == null)
            {
                return NotFound();
            }

            UpdatedRecord.Date = updateVisitRecordDto.Date;
            UpdatedRecord.Diagnosis = updateVisitRecordDto.Diagnosis;
            UpdatedRecord.Treatment = updateVisitRecordDto.Treatment;
            dbcontext.SaveChanges();
            return Ok(UpdatedRecord);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteVisitRecord(Guid id)
        {
            var DeletedVisitRecord = dbcontext.VisitRecords.Find(id);

            if (DeletedVisitRecord == null)
            {
                return NotFound();
            }

            dbcontext.VisitRecords.Remove(DeletedVisitRecord);
            dbcontext.SaveChanges();
            return Ok(DeletedVisitRecord);
        }
    }
}
