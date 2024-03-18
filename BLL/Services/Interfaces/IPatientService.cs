using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ServiceResponse<List<PatientModel>>> GetPatientList();
        Task<ServiceResponse<PatientModel>> GetPatientByPhone(String phoneNumber);
        Task<ServiceResponse<PatientModel>> AddPatient(PatientModel patientModel);
        Task<ServiceResponse<PatientModel>> UpdatePatient(PatientModel patientModel);
        Task<ServiceResponse<Boolean>> DeletePatient(String phoneNumber);
    }
}
