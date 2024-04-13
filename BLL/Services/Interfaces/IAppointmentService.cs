using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<List<AppointmentDTO>>> GetAppointmentList(DateTime appointmentDate);
        Task<ServiceResponse<List<AppointmentDTO>>> GetAppointmentByPatient(Int32 id);
        Task<ServiceResponse<AppointmentAddDTO>> AddAppointment(AppointmentAddDTO appointmentModel);
        Task<ServiceResponse<AppointmentAddDTO>> UpdateProcedure(AppointmentAddDTO appointmentModel);
        Task<ServiceResponse<Boolean>> DeleteProcedure(Int32 id);
    }
}
