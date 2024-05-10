using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IAppointmentDescriptionService
    {
        Task<ServiceResponse<List<AppointmentDescriptionDTO>>> GetByAppointment(Int32 id);
        Task<ServiceResponse<AppointmentDescriptionDTO>> AddAppointmentDescription(AppointmentDescriptionDTO appointmentModel);
        Task<ServiceResponse<AppointmentDescriptionDTO>> UpdateAppointmentDescription(AppointmentDescriptionDTO appointmentModel);
        Task<ServiceResponse<Boolean>> DeleteAppointmentDescription(Int32 id);
    }
}
