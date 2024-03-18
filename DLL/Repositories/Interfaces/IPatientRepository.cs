using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<PatientEntityModel> GetByPhone(String phoneNumber);
        Task<List<PatientEntityModel>> GetAll();
        Task AddPatient(PatientEntityModel patientEntityModel);
        Task UpdatePatient(PatientEntityModel patientEntityModel);
        Task Delete(PatientEntityModel patientEntityModel);
        Task<Boolean> IsPatientExistByPhone(String phoneNumber);
        Task<Boolean> IsPatientExistById(Int32? id);
    }
}
