using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class PatientMapper
    {
        public static Client GetPatientAddModel(PatientDTO patientModel)
        {
            Client patientEntityModel = new()
            {
                Name = patientModel.Name,
                Surname = patientModel.Surname,
                Patronymic = patientModel.Patronymic,
                Birthday = patientModel.Birthday,
                PhoneNumber = patientModel.PhoneNumber
            };
            return patientEntityModel;
        }

        public static Client GetPatientUpdateModel(PatientDTO patientModel)
        {
            Client patientEntityModel = new()
            {
                Id = patientModel.Id ?? default,
                Name = patientModel.Name,
                Surname = patientModel.Surname,
                Patronymic = patientModel.Patronymic,
                Birthday = patientModel.Birthday,
                PhoneNumber = patientModel.PhoneNumber
            };
            return patientEntityModel;
        }

        public static PatientDTO GetPatientModel(Client patientEntityModel)
        {
            PatientDTO patientModel = new()
            {
                Id = patientEntityModel.Id,
                Name = patientEntityModel.Name,
                Surname = patientEntityModel.Surname,
                Patronymic = patientEntityModel.Patronymic,
                Birthday = patientEntityModel.Birthday,
                PhoneNumber = patientEntityModel.PhoneNumber
            };
            return patientModel;
        }
    }
}
