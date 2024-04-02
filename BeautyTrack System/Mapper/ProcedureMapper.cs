using BeautyTrack_System.Models.ProcedureModels;
using BeautyTrackSystem.BLL.Models.ProcedureDTOs;

namespace BeautyTrack_System.Mapper
{
    public class ProcedureMapper
    {
        public static ProcedureDTO GetProcedureModel(ProcedureViewModel procedureViewModel)
        {
            ProcedureDTO procedure = new ProcedureDTO
            {
                Id = procedureViewModel.Id,
                ProcedureName = procedureViewModel.ProcedureName
            };
            return procedure;
        }
    }
}
