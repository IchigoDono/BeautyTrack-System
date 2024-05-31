using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetByPatientId(Int32 id);
        Task<List<Appointment>> GetByDate(DateTime appointmentDate);
        Task<List<Appointment>> GetAll();
        Task<Appointment> GetById(Int32 id);
        Task AddAppointment(Appointment appointmentEntityModel);
        Task UpdateAppointment(Appointment appointmentEntityModel);
        Task Delete(Appointment appointmentEntityModel);
        Task<Boolean> IsAppointmentExistByPhone(String? phoneNumber);
        Task<Boolean> IsAppointmentExistById(Int32? id);
    }
}
