namespace BeautyTrackSystem.DLL.Models.Entities
{
    public class PatientEntityModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public String PhomeNumber { get; set; }
    }
}
