using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;
using DLL;
using Microsoft.EntityFrameworkCore;

namespace BeautyTrackSystem.DLL.Repositories.Realization
{
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ProcedureRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Procedure> GetById(Int32 id)
        {
            Procedure procedureEntityModel =
                 await _applicationContext.Procedures.FirstOrDefaultAsync(u => u.Id.Equals(id));
            return procedureEntityModel;
        }
        public async Task<List<Procedure>> GetAll()
        {
            List<Procedure> procedureEntityModel =
                await _applicationContext.Procedures.ToListAsync();
            return procedureEntityModel;
        }

        public async Task<Boolean> IsProcedureExistByName(String? procedureName)
        {
            Boolean success = await _applicationContext.Procedures.AnyAsync(x => x.ProcedureName == procedureName);
            return success;
        }

        public async Task<Boolean> IsProcedureExist(String? procedureName, Int32? id)
        {
            Boolean success = await _applicationContext.Procedures.AnyAsync(x => x.ProcedureName == procedureName && x.Id != id);
            return success;
        }

        public async Task<Boolean> IsProcedureExistById(Int32? id)
        {
            Boolean success = await _applicationContext.Procedures.AnyAsync(x => x.Id == id);
            return success;
        }

        public async Task AddProcedure(Procedure procedureEntityModel)
        {
            _applicationContext.Procedures.Add(procedureEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Delete(Procedure procedureEntityModel)
        {
            _applicationContext.Procedures.Remove(procedureEntityModel);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdateProcedure(Procedure procedureEntityModel)
        {
            _applicationContext.Procedures.Update(procedureEntityModel);
            await _applicationContext.SaveChangesAsync();
        }
    }
}