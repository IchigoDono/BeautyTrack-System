using BeautyTrack_System.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.PatientModels;

namespace BeautyTrack_System.Mapper
{
    public class PatientMapper
    {
        public static PatientModel GetPatientModel(PatientViewModel loginViewModel)
        {
            PatientModel patient = new PatientModel
            {
                Id = loginViewModel.Id,
                Name = loginViewModel.Name,
                Surname = loginViewModel.Surname,   
                Patronymic = loginViewModel.Patronymic,
                Birthday = loginViewModel.Birthday,
                PhomeNumber = loginViewModel.PhomeNumber
            };
            return patient;
        }
    }
}
