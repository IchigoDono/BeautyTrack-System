namespace BeautyTrackSystem.BLL.Models.AppointmentDTOs
{
    public class AppointmentDescriptionDTO
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public Int32 AppointmentId { get; set; }
    }
}
