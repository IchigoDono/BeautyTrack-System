﻿using BeautyTrackSystem.DLL.Models.Entities;
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

        public async Task<PatientEntityModel> GetByPhone(String phoneNumber)
        {
            PatientEntityModel patientEntityModel =
                 await _applicationContext.Patients.FirstOrDefaultAsync(u => u.PhomeNumber.Equals(phoneNumber));
            return patientEntityModel;
        }
        public async Task<List<PatientEntityModel>> GetAll()
        {
            List<PatientEntityModel> patientEntityModels =
                await _applicationContext.Patients.ToListAsync();
            return patientEntityModels;
        }

        public async Task<Boolean> IsPatientExistByPhone(string phoneNumber)
        {
            Boolean success = await _applicationContext.Patients.AnyAsync(x => x.PhomeNumber == phoneNumber);
            return success;
        }

        public async Task<Boolean> IsPatientExistById(Int32? id)
        {
            Boolean success = await _applicationContext.Patients.AnyAsync(x => x.Id == id);
            return success;

        }

        public async Task AddPatient(PatientEntityModel patientEntityModel)
        {
            _applicationContext.Patients.Add(patientEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(PatientEntityModel patientEntityModel)
        {
            _applicationContext.Patients.Remove(patientEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdatePatient(PatientEntityModel patientEntityModel)
        {
            _applicationContext.Patients.Update(patientEntityModel);
            await _applicationContext.SaveChangesAsync();
        }
    }
}