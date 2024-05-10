namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class AppointmentDescription
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public Int32 AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
