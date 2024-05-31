namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class Client
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Patronymic { get; set; }
        public DateOnly Birthday { get; set; }
        public String PhoneNumber { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
