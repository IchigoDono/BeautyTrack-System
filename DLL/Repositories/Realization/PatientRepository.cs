using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;
using DLL;
using Microsoft.EntityFrameworkCore;

namespace BeautyTrackSystem.DLL.Repositories.Realization
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationContext _applicationContext;
        public PatientRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Patient> GetByPhone(String phoneNumber)
        {
            Patient patientEntityModel =
                 await _applicationContext.Patients.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(phoneNumber));
            return patientEntityModel;
        }
        public async Task<List<Patient>> GetAll()
        {
            List<Patient> patientEntityModels =
                await _applicationContext.Patients.ToListAsync();
            return patientEntityModels;
        }

        public async Task<Boolean> IsPatientExistByPhone(string phoneNumber)
        {
            Boolean success = await _applicationContext.Patients.AnyAsync(x => x.PhoneNumber == phoneNumber);
            return success;
        }

        public async Task<Boolean> IsPatientExistById(Int32? id)
        {
            Boolean success = await _applicationContext.Patients.AnyAsync(x => x.Id == id);
            return success;

        }

        public async Task AddPatient(Patient patientEntityModel)
        {
            _applicationContext.Patients.Add(patientEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(Patient patientEntityModel)
        {
            _applicationContext.Patients.Remove(patientEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdatePatient(Patient patientEntityModel)
        {
            _applicationContext.Patients.Update(patientEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<Patient> GetById(Int32 id)
        {
            Patient patientEntityModel =
                 await _applicationContext.Patients.FirstOrDefaultAsync(u => u.Id == id);
            return patientEntityModel;
        }
    }
}