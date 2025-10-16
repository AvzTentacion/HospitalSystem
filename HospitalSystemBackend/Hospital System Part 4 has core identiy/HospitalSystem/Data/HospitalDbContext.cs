using HospitalSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Data
{
    public class HospitalDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<VisitRecord> VisitRecords { get; set; }

        public DbSet<MedicalAidCompany> MedicalAidCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");
        }
    }
}
