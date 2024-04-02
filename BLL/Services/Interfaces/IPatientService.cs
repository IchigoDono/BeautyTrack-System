using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ServiceResponse<List<PatientDTO>>> GetPatientList();
        Task<ServiceResponse<PatientDTO>> GetPatientByPhone(String phoneNumber);
        Task<ServiceResponse<PatientDTO>> AddPatient(PatientDTO patientModel);
        Task<ServiceResponse<PatientDTO>> UpdatePatient(PatientDTO patientModel);
        Task<ServiceResponse<Boolean>> DeletePatient(String phoneNumber);
    }
}
