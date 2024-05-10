using BeautyTrack_System.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.PatientModels;

namespace BeautyTrack_System.Mapper
{
    public class PatientMapper
    {
        public static PatientDTO GetPatientModel(PatientViewModel patientViewModel)
        {
            PatientDTO patient = new PatientDTO
            {
                Id = patientViewModel.Id,
                Name = patientViewModel.Name,
                Surname = patientViewModel.Surname,
                Patronymic = patientViewModel.Patronymic,
                Birthday = new DateOnly(patientViewModel.Birthday.Year, patientViewModel.Birthday.Month, patientViewModel.Birthday.Day),
                PhoneNumber = patientViewModel.PhoneNumber
            };
            return patient;
        }
    }
}
