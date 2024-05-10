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
        public DbSet<AppointmentDescription> AppointmentDescriptions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Appointment>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Patient>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Procedure>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AppointmentDescription>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Appointment>()
                .HasOne(s => s.Patient)
                .WithMany(g => g.Appointments)
                .HasForeignKey(s => s.PatientId);


            modelBuilder.Entity<Appointment>()
                .HasOne(s => s.Procedure)
                .WithMany(g => g.Appointments)
                .HasForeignKey(s => s.ProcedureId);

            modelBuilder.Entity<AppointmentDescription>()
                .HasOne(s => s.Appointment)
                .WithMany(x => x.AppointmentDescriptions)
                .HasForeignKey(s => s.AppointmentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
