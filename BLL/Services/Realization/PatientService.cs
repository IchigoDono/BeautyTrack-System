using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ServiceResponse<List<PatientEntityModel>>> GetPatientList()
        {
            ServiceResponse<List<PatientEntityModel>> serviceResponse = new ServiceResponse<List<PatientEntityModel>>();

            List<PatientEntityModel> patientEntityModel = await _patientRepository.GetAll();

            if (patientEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = patientEntityModel;
            return serviceResponse;
        }
        public async Task<ServiceResponse<PatientEntityModel>> GetPatientById(Int32 id)
        {
            ServiceResponse<PatientEntityModel> serviceResponse = new ServiceResponse<PatientEntityModel>();

            PatientEntityModel patientEntityModel = await _patientRepository.Get(id);

            if (patientEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = patientEntityModel;
            return serviceResponse;
        }
    }
}
