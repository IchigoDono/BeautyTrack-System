namespace BeautyTrackSystem.BLL.Models.AppointmentDTOs
{
    public class AppointmentGetDTO
    {
        public Int32 Id { get; set; }
        public String Date { get; set; }
        public String FullName { get; set; }
        public String ProcedureName { get; set; }
        public Decimal Price { get; set; }

    }
}
