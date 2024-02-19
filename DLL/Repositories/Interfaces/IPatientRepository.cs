using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<PatientEntityModel> Get(Int32 id);
        Task<List<PatientEntityModel>> GetAll();
    }
}
