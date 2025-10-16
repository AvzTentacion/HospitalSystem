using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.Models
{
    public class Roles : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
