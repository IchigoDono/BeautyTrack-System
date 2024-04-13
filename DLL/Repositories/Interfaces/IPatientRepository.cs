using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetByPhone(String phoneNumber);
        Task<Patient> GetById(Int32 id);
        Task<List<Patient>> GetAll();
        Task AddPatient(Patient patientEntityModel);
        Task UpdatePatient(Patient patientEntityModel);
        Task Delete(Patient patientEntityModel);
        Task<Boolean> IsPatientExistByPhone(String phoneNumber);
        Task<Boolean> IsPatientExistById(Int32? id);
    }
}
