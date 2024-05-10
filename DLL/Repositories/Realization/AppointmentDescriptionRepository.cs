using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;
using DLL;
using Microsoft.EntityFrameworkCore;

namespace BeautyTrackSystem.DLL.Repositories.Realization
{
    public class AppointmentDescriptionRepository : IAppointmentDescriptionRepository
    {
        private readonly ApplicationContext _applicationContext;
        public AppointmentDescriptionRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<AppointmentDescription>> GetByAppointmentId(Int32 id)
        {
            List<AppointmentDescription> appointmentEntityModel =
                 await _applicationContext.AppointmentDescriptions
                 .Include(u => u.Appointment)
                 .Where(u => u.AppointmentId == id)
                 .ToListAsync();
            return appointmentEntityModel;
        }

        public async Task<Boolean> IsAppointmentDescriptionExistById(Int32? id)
        {
            Boolean success = await _applicationContext.AppointmentDescriptions.AnyAsync(x => x.Id == id);
            return success;
        }

        public async Task AddAppointmentDescription(AppointmentDescription appointmentEntityModel)
        {
            _applicationContext.AppointmentDescriptions.Add(appointmentEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(AppointmentDescription appointmentEntityModel)
        {
            _applicationContext.AppointmentDescriptions.Remove(appointmentEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdateAppointmentDescription(AppointmentDescription appointmentEntityModel)
        {
            _applicationContext.AppointmentDescriptions.Update(appointmentEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<AppointmentDescription> GetById(Int32 id)
        {
            AppointmentDescription appointmentEntityModel = await _applicationContext.AppointmentDescriptions.FirstOrDefaultAsync(u => u.Id == id);
            return appointmentEntityModel;
        }
    }
}