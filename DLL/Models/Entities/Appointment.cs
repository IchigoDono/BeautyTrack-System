namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ProcedureId { get; set; }
        public decimal Price { get; set; }
    }
}
