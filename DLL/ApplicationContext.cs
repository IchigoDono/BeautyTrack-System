using BeautyTrackSystem.DLL.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace DLL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
          .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
