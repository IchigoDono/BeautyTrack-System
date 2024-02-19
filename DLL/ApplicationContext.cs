using BeautyTrackSystem.DLL.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace DLL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PatientEntityModel> Patients { get; set; }
        public DbSet<ProcedureEntityModel> Procedures { get; set; }
        public DbSet<AppointmentEntityModel> Appointments { get; set; }
        public DbSet<UserEntityModel> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) 
        {
        }
    }
}
