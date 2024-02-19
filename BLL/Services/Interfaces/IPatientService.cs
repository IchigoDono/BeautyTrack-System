using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.DLL.Models.Entities;    

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ServiceResponse<List<PatientEntityModel>>> GetPatientList();
        Task<ServiceResponse<PatientEntityModel>> GetPatientById(Int32 id);
    }
}
