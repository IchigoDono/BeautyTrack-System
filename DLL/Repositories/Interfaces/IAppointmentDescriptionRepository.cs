using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IAppointmentDescriptionRepository
    {
        Task<List<AppointmentDescription>> GetByAppointmentId(Int32 id);
        Task<AppointmentDescription> GetById(Int32 id);
        Task AddAppointmentDescription(AppointmentDescription appointmentEntityModel);
        Task UpdateAppointmentDescription(AppointmentDescription appointmentEntityModel);
        Task Delete(AppointmentDescription appointmentEntityModel);
        Task<Boolean> IsAppointmentDescriptionExistById(Int32? id);
    }
}
