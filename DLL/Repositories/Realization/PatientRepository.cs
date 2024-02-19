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

        public async Task<PatientEntityModel> Get(Int32 id)
        {
            PatientEntityModel patientEntityModel =
                 await _applicationContext.Patients.FirstOrDefaultAsync(u => u.PhomeNumber.Equals(id));
            return patientEntityModel;
        }
        public async Task<List<PatientEntityModel>> GetAll()
        {
            List<PatientEntityModel> patientEntityModels =
                await _applicationContext.Patients.ToListAsync();
            return patientEntityModels;
        }
    }
}