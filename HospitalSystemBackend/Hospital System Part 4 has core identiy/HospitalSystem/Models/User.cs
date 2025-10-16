using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.Models
{
    public class User : IdentityUser<Guid>
    {

        public List<VisitRecord> VisitRecords { get; set; } = new();
    }
}
