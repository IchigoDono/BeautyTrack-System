using BeautyTrackSystem.BLL.Models.ProcedureDTOs;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class ProcedureMapper
    {
        public static ProcedureDTO GetProcedureModel(Procedure procedureEntityModel)
        {
            ProcedureDTO procedureModel = new()
            {
                Id = procedureEntityModel.Id,
                ProcedureName = procedureEntityModel.ProcedureName
            };
            return procedureModel;
        }

        public static Procedure GetProcedureAddModel(ProcedureDTO procedureModel)
        {
            Procedure procedureEntityModel = new()
            {
                ProcedureName = procedureModel.ProcedureName
            };
            return procedureEntityModel;
        }
        public static Procedure GetProcedureUpdateModel(ProcedureDTO procedureModel)
        {
            Procedure procedureEntityModel = new()
            {
                Id = procedureModel.Id ?? default,
                ProcedureName = procedureModel.ProcedureName
            };
            return procedureEntityModel;
        }
    }
}
