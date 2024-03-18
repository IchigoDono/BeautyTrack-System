using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class PatientMapper
    {
        public static PatientEntityModel GetPatientEntityModel(PatientModel patientModel)
        {
            PatientEntityModel patientEntityModel = new PatientEntityModel
            {
                Id = patientModel.Id,
                Name = patientModel.Name,
                Surname = patientModel.Surname,
                Patronymic = patientModel.Patronymic,
                Birthday = patientModel.Birthday,
                PhomeNumber = patientModel.PhomeNumber
            };
            return patientEntityModel;
        }

        public static PatientModel GetPatientModel(PatientEntityModel patientEntityModel)
        {
            PatientModel patientModel = new PatientModel
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
