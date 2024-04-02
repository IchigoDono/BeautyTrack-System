using BeautyTrackSystem.BLL.Models.ProcedureDTOs;
using BeautyTrackSystem.BLL.Models.Responses;

namespace BeautyTrackSystem.BLL.Services.Interfaces
{
    public interface IProcedureService
    {
        Task<ServiceResponse<List<ProcedureDTO>>> GetProcedureList();
        Task<ServiceResponse<ProcedureDTO>> GetProcedureById(Int32 id);
        Task<ServiceResponse<ProcedureDTO>> AddProcedure(ProcedureDTO procedureModel);
        Task<ServiceResponse<ProcedureDTO>> UpdateProcedure(ProcedureDTO procedureModel);
        Task<ServiceResponse<Boolean>> DeleteProcedure(Int32 id);
    }
}
