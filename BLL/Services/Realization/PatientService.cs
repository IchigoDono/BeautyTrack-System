using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models.PatientModels;
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

        public async Task<ServiceResponse<List<PatientModel>>> GetPatientList()
        {
            ServiceResponse<List<PatientModel>> serviceResponse = new ServiceResponse<List<PatientModel>>();

            List<PatientEntityModel> patientEntityModel = await _patientRepository.GetAll();

            if (patientEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            List<PatientModel> patientModels = patientEntityModel
                .Select(patientEntity => PatientMapper.GetPatientModel(patientEntity))
                .ToList();

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = patientModels;
            return serviceResponse;
        }
        public async Task<ServiceResponse<PatientModel>> GetPatientByPhone(String phoneNumber)
        {
            ServiceResponse<PatientModel> serviceResponse = new ServiceResponse<PatientModel>();

            PatientEntityModel patientEntityModel = await _patientRepository.GetByPhone(phoneNumber);

            if (patientEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = PatientMapper.GetPatientModel(patientEntityModel);
            return serviceResponse;
        }

        public async Task<ServiceResponse<PatientModel>> AddPatient(PatientModel patientModel)
        {
            ServiceResponse<PatientModel> serviceResponse = new ServiceResponse<PatientModel>();

            Boolean isPatientExists = await _patientRepository.IsPatientExistByPhone(patientModel.PhomeNumber);
            if (isPatientExists)
            {
                serviceResponse.Message = "Patient already exist";
                return serviceResponse;
            }

            PatientEntityModel patientEntityModel = PatientMapper.GetPatientEntityModel(patientModel);

            await _patientRepository.AddPatient(patientEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = patientModel;
            return serviceResponse;
        }
        public async Task<ServiceResponse<PatientModel>> UpdatePatient(PatientModel patientModel)
        {
            ServiceResponse<PatientModel> serviceResponse = new ServiceResponse<PatientModel>();

            Boolean isPatientExists = await _patientRepository.IsPatientExistById(patientModel.Id);
            if (!isPatientExists)
            {
                serviceResponse.Message = "Patient is not exist";
                return serviceResponse;
            }

            PatientEntityModel patientEntityModel = PatientMapper.GetPatientEntityModel(patientModel);

            await _patientRepository.UpdatePatient(patientEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = patientModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Boolean>> DeletePatient(String phoneNumber)
        {
            ServiceResponse<Boolean> serviceResponse = new ServiceResponse<Boolean>();
            Boolean isPatientExists = await _patientRepository.IsPatientExistByPhone(phoneNumber);

            if (!isPatientExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Patient is not exist";
                return serviceResponse;
            }

            PatientEntityModel patientEntityModel = new PatientEntityModel();
            patientEntityModel = await _patientRepository.GetByPhone(phoneNumber);

            await _patientRepository.Delete(patientEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }


    }
}
