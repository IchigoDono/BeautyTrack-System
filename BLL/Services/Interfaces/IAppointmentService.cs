using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<List<AppointmentGetDTO>>> GetAppointmentList();
        Task<ServiceResponse<List<AppointmentGetDTO>>> GetAppointmentListByDate(DateTime appointmentDate);
        Task<ServiceResponse<MemoryStream>> GetReport(DateTime appointmentDate);
        Task<ServiceResponse<List<AppointmentGetDTO>>> GetAppointmentByPatient(Int32 id);
        Task<ServiceResponse<AppointmentAddDTO>> AddAppointment(AppointmentAddDTO appointmentModel);
        Task<ServiceResponse<AppointmentAddDTO>> UpdateProcedure(AppointmentAddDTO appointmentModel);
        Task<ServiceResponse<Boolean>> DeleteProcedure(Int32 id);
    }
}
