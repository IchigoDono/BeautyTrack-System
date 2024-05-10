namespace BeautyTrackSystem.BLL.Models.PatientModels
{
    public class PatientDTO
    {
        public Int32? Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Patronymic { get; set; }
        public DateOnly Birthday { get; set; }
        public String PhoneNumber { get; set; }
    }
}
