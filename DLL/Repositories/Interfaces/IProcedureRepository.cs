using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.DLL.Repositories.Interfaces
{
    public interface IProcedureRepository
    {
        Task<Procedure> GetById(Int32 id);
        Task<List<Procedure>> GetAll();
        Task AddProcedure(Procedure procedureEntityModel);
        Task UpdateProcedure(Procedure procedureEntityModel);
        Task Delete(Procedure procedureEntityModel);
        Task<Boolean> IsProcedureExistByName(String? procedureName);
        Task<Boolean> IsProcedureExistById(Int32? id);
    }
}
