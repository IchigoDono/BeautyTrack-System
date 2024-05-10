using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;
using DLL;
using Microsoft.EntityFrameworkCore;

namespace BeautyTrackSystem.DLL.Repositories.Realization
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationContext _applicationContext;
        public AppointmentRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<List<Appointment>> GetByPatientId(Int32 id)
        {
            List<Appointment> appointmentEntityModel =
                 await _applicationContext.Appointments
                 .Include(u => u.Patient)
                 .Include(u => u.Procedure)
                 .Where(u => u.PatientId == id)
                 .ToListAsync();
            return appointmentEntityModel;
        }
        public async Task<List<Appointment>> GetByDate(DateTime appointmentDate)
        {
            List<Appointment> appointmentEntityModel =
                 await _applicationContext.Appointments
                 .Include(u => u.Patient)
                 .Include(u => u.Procedure)
                 .Where(u => u.Date.Date == appointmentDate.Date)
                 .ToListAsync();
            return appointmentEntityModel;
        }

        public async Task<Boolean> IsAppointmentExistByPhone(String? phoneNumber)
        {
            Boolean success = await _applicationContext.Appointments.AnyAsync(x => x.Patient.PhoneNumber == phoneNumber);
            return success;
        }

        public async Task<Boolean> IsAppointmentExistById(Int32? id)
        {
            Boolean success = await _applicationContext.Procedures.AnyAsync(x => x.Id == id);
            return success;
        }

        public async Task AddAppointment(Appointment appointmentEntityModel)
        {
            _applicationContext.Appointments.Add(appointmentEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(Appointment appointmentEntityModel)
        {
            _applicationContext.Appointments.Remove(appointmentEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdateAppointment(Appointment appointmentEntityModel)
        {
            _applicationContext.Appointments.Update(appointmentEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<Appointment> GetById(Int32 id)
        {
            Appointment appointmentEntityModel = await _applicationContext.Appointments.FirstOrDefaultAsync(u => u.Id == id);
            return appointmentEntityModel;
        }
    }
}