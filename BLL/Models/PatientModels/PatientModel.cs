namespace BeautyTrackSystem.BLL.Models.PatientModels
{
    public class PatientModel
    {
        public Int32? Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Patronymic { get; set; }
        public DateOnly Birthday { get; set; }
        public String PhomeNumber { get; set; }
    }
}
