using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientService> _logger;
        public PatientService(IPatientRepository patientRepository,
            ILogger<PatientService> logger)
        {
            _patientRepository = patientRepository;
            _logger = logger;
        }

        public async Task<ServiceResponse<List<PatientDTO>>> GetPatientList()
        {
            ServiceResponse<List<PatientDTO>> serviceResponse = new ServiceResponse<List<PatientDTO>>();

            List<Client> patientEntityModel = await _patientRepository.GetAll();

            if (patientEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            List<PatientDTO> patientModels = patientEntityModel
                .Select(patientEntity => PatientMapper.GetPatientModel(patientEntity))
                .ToList();

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = patientModels;
            return serviceResponse;
        }
        public async Task<ServiceResponse<PatientDTO>> GetPatientByPhone(String phoneNumber)
        {
            try 
            {
                ServiceResponse<PatientDTO> serviceResponse = new ServiceResponse<PatientDTO>();

                Client patientEntityModel = await _patientRepository.GetByPhone(phoneNumber);

                if (patientEntityModel == null)
                {
                    serviceResponse.Message = "Answer is null";
                    return serviceResponse;
                }

                serviceResponse.IsSuccess = true;
                serviceResponse.Data = PatientMapper.GetPatientModel(patientEntityModel);
                return serviceResponse;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<ServiceResponse<PatientDTO>> AddPatient(PatientDTO patientModel)
        {
            try
            {
                ServiceResponse<PatientDTO> serviceResponse = new ServiceResponse<PatientDTO>();

                Boolean isPatientExists = await _patientRepository.IsPatientExistByPhone(patientModel.PhoneNumber);
                if (isPatientExists)
                {
                    serviceResponse.Message = "Patient already exist";
                    return serviceResponse;
                }

                Client patientEntityModel = PatientMapper.GetPatientAddModel(patientModel);

                await _patientRepository.AddPatient(patientEntityModel);

                serviceResponse.IsSuccess = true;
                serviceResponse.Data = patientModel;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public async Task<ServiceResponse<PatientDTO>> UpdatePatient(PatientDTO patientModel)
        {
            ServiceResponse<PatientDTO> serviceResponse = new ServiceResponse<PatientDTO>();

            Boolean isPatientIdExists = await _patientRepository.IsPatientExistById(patientModel.Id);
            if (!isPatientIdExists)
            {
                serviceResponse.Message = "Patient is not exist";
                return serviceResponse;
            }

            //Boolean isPatientNameExists = await _patientRepository.IsPatientExistByPhone(patientModel.PhomeNumber);
            //if (isPatientNameExists)
            //{
            //    serviceResponse.Message = "Patient already exist";
            //    return serviceResponse;
            //}

            Client patientEntityModel = PatientMapper.GetPatientUpdateModel(patientModel);

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

            Client patientEntityModel = new Client();
            patientEntityModel = await _patientRepository.GetByPhone(phoneNumber);

            await _patientRepository.Delete(patientEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }


    }
}
