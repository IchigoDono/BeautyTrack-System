namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class Procedure
    {
        public Int32 Id { get; set; }
        public String ProcedureName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
