namespace BeautyTrackSystem.BLL.Models.AppointmentDTOs
{
    public class AppointmentDTO
    {
        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public String FullName { get; set; }
        public String ProcedureName { get; set; }
        public Decimal Price { get; set; }

    }
}
