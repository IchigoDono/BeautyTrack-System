using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Client> GetByPhone(String phoneNumber);
        Task<Client> GetById(Int32 id);
        Task<List<Client>> GetAll();
        Task AddPatient(Client patientEntityModel);
        Task UpdatePatient(Client patientEntityModel);
        Task Delete(Client patientEntityModel);
        Task<Boolean> IsPatientExistByPhone(String phoneNumber);
        Task<Boolean> IsPatientExistById(Int32? id);
    }
}
