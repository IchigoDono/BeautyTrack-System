using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class PatientMapper
    {
        public static Patient GetPatientAddModel(PatientDTO patientModel)
        {
            Patient patientEntityModel = new()
            {
                Name = patientModel.Name,
                Surname = patientModel.Surname,
                Patronymic = patientModel.Patronymic,
                Birthday = patientModel.Birthday,
                PhomeNumber = patientModel.PhomeNumber
            };
            return patientEntityModel;
        }

        public static Patient GetPatientUpdateModel(PatientDTO patientModel)
        {
            Patient patientEntityModel = new()
            {
                Id = patientModel.Id ?? default,
                Name = patientModel.Name,
                Surname = patientModel.Surname,
                Patronymic = patientModel.Patronymic,
                Birthday = patientModel.Birthday,
                PhomeNumber = patientModel.PhomeNumber
            };
            return patientEntityModel;
        }

        public static PatientDTO GetPatientModel(Patient patientEntityModel)
        {
            PatientDTO patientModel = new()
            {
                Id = patientEntityModel.Id,
                Name = patientEntityModel.Name,
                Surname = patientEntityModel.Surname,
                Patronymic = patientEntityModel.Patronymic,
                Birthday = patientEntityModel.Birthday,
                PhomeNumber = patientEntityModel.PhomeNumber
            };
            return patientModel;
        }
    }
}
