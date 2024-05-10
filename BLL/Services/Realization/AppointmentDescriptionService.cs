using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class AppointmentDescriptionService : IAppointmentDescriptionService
    {
        private readonly IAppointmentDescriptionRepository _appointmentDescriptionRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentDescriptionService(IAppointmentDescriptionRepository appointmentDescriptionRepository, IAppointmentRepository appointmentRepository)
        {
            _appointmentDescriptionRepository = appointmentDescriptionRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<ServiceResponse<List<AppointmentDescriptionDTO>>> GetByAppointment(Int32 id)
        {
            ServiceResponse<List<AppointmentDescriptionDTO>> serviceResponse = new ServiceResponse<List<AppointmentDescriptionDTO>>();

            Boolean isAppointmentExists = await _appointmentRepository.IsAppointmentExistById(id);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Appointment is not exist";
                return serviceResponse;
            }

            List<AppointmentDescription> appointmentDescription = await _appointmentDescriptionRepository.GetByAppointmentId(id);

            if (appointmentDescription == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentDescription
                .Select(appointmentEntity => AppointmentDescriptionMapper.GetAppointmentModel(appointmentEntity))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<AppointmentDescriptionDTO>> AddAppointmentDescription(AppointmentDescriptionDTO appointmentModel)
        {
            ServiceResponse<AppointmentDescriptionDTO> serviceResponse = new ServiceResponse<AppointmentDescriptionDTO>();

            Boolean isAppointmentExists = await _appointmentRepository.IsAppointmentExistById(appointmentModel.AppointmentId);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Appointment is not exist";
                return serviceResponse;
            }

            AppointmentDescription appointmentDescription = AppointmentDescriptionMapper.GetAppointmentAddModel(appointmentModel);

            await _appointmentDescriptionRepository.AddAppointmentDescription(appointmentDescription);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<AppointmentDescriptionDTO>> UpdateAppointmentDescription(AppointmentDescriptionDTO appointmentModel)
        {
            ServiceResponse<AppointmentDescriptionDTO> serviceResponse = new ServiceResponse<AppointmentDescriptionDTO>();

            Boolean isAppointmentDescriptionExists = await _appointmentDescriptionRepository.IsAppointmentDescriptionExistById(appointmentModel.Id);

            if (!isAppointmentDescriptionExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "AppointmentDescription is not exist";
                return serviceResponse;
            }

            Boolean isAppointmentExists = await _appointmentRepository.IsAppointmentExistById(appointmentModel.AppointmentId);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Appointment is not exist";
                return serviceResponse;
            }


            AppointmentDescription appointment = AppointmentDescriptionMapper.GetAppointmentUpdateModel(appointmentModel);

            await _appointmentDescriptionRepository.UpdateAppointmentDescription(appointment);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentModel;
            return serviceResponse;
        }
        public async Task<ServiceResponse<Boolean>> DeleteAppointmentDescription(Int32 id)
        {
            ServiceResponse<Boolean> serviceResponse = new ServiceResponse<Boolean>();
            Boolean isAppointmentExists = await _appointmentDescriptionRepository.IsAppointmentDescriptionExistById(id);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Procedure is not exist";
                return serviceResponse;
            }

            AppointmentDescription appointment = new AppointmentDescription();
            appointment = await _appointmentDescriptionRepository.GetById(id);

            await _appointmentDescriptionRepository.Delete(appointment);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }

    }
}
