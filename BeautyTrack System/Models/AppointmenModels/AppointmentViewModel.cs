namespace BeautyTrack_System.Models.AppointmenModels
{
    public class AppointmentViewModel
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public Int32 PatientId { get; set; }
        public Int32 ProcedureId { get; set; }
        public Decimal Price { get; set; }
    }
}
