using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<ServiceResponse<AppointmentAddDTO>> AddAppointment(AppointmentAddDTO appointmentModel)
        {
            ServiceResponse<AppointmentAddDTO> serviceResponse = new ServiceResponse<AppointmentAddDTO>();

            Appointment appointmentEntityModel = AppointmentMapper.GetAppointmentAddModel(appointmentModel);

            await _appointmentRepository.AddAppointment(appointmentEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<AppointmentAddDTO>> UpdateProcedure(AppointmentAddDTO appointmentModel)
        {
            ServiceResponse<AppointmentAddDTO> serviceResponse = new ServiceResponse<AppointmentAddDTO>();

            Boolean isAppointmentExists = await _appointmentRepository.IsAppointmentExistById(appointmentModel.Id);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Appointment is not exist";
                return serviceResponse;
            }

            Appointment appointmentEntityModel = AppointmentMapper.GetAppointmentUpdateModel(appointmentModel);

            await _appointmentRepository.UpdateAppointment(appointmentEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentModel;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<AppointmentDTO>>> GetAppointmentByPatient(Int32 id)
        {
            ServiceResponse<List<AppointmentDTO>> serviceResponse = new ServiceResponse<List<AppointmentDTO>>();

            List<Appointment> appointmentEntityModel = await _appointmentRepository.GetByPatientId(id);

            if (appointmentEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentEntityModel
                .Select(appointmentEntity => AppointmentMapper.GetAppointmenModel(appointmentEntity))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AppointmentDTO>>> GetAppointmentList(DateTime appointmentDate)
        {
            ServiceResponse<List<AppointmentDTO>> serviceResponse = new ServiceResponse<List<AppointmentDTO>>();

            List<Appointment> appointmentEntityModel = await _appointmentRepository.GetByDate(appointmentDate);

            if (appointmentEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = appointmentEntityModel
                .Select(appointmentEntity => AppointmentMapper.GetAppointmenModel(appointmentEntity))
                .ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteProcedure(int id)
        {
            ServiceResponse<Boolean> serviceResponse = new ServiceResponse<Boolean>();
            Boolean isAppointmentExists = await _appointmentRepository.IsAppointmentExistById(id);

            if (!isAppointmentExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Procedure is not exist";
                return serviceResponse;
            }

            Appointment appointmentEntityModel = new Appointment();
            appointmentEntityModel = await _appointmentRepository.GetById(id);

            await _appointmentRepository.Delete(appointmentEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }
    }
}
