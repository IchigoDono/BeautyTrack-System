namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class Appointment
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public Int32 PatientId { get; set; }
        public Int32 ProcedureId { get; set; }
        public Decimal Price { get; set; }
        public Patient Patient { get; set; }
        public Procedure Procedure { get; set; }
        public ICollection<AppointmentDescription> AppointmentDescriptions { get; set; } = new HashSet<AppointmentDescription>();
    }
}
