namespace BeautyTrackSystem.BLL.Models.AppointmentDTOs
{
    public class AppointmentAddDTO
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public Int32 PatientId { get; set; }
        public Int32 ProcedureId { get; set; }
        public Decimal Price { get; set; }
    }
}
