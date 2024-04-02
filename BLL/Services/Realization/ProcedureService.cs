using BeautyTrackSystem.BLL.Mapper;
using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.ProcedureDTOs;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using BeautyTrackSystem.DLL.Repositories.Interfaces;

namespace BeautyTrackSystem.BLL.Services.Realization
{
    public class ProcedureService : IProcedureService
    {
        private readonly IProcedureRepository _procedureRepository;
        public ProcedureService(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public async Task<ServiceResponse<List<ProcedureDTO>>> GetProcedureList()
        {
            ServiceResponse<List<ProcedureDTO>> serviceResponse = new ServiceResponse<List<ProcedureDTO>>();

            List<Procedure> procedureEntityModel = await _procedureRepository.GetAll();

            if (procedureEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            List<ProcedureDTO> procedureModels = procedureEntityModel
                .Select(procedureEntity => ProcedureMapper.GetProcedureModel(procedureEntity))
                .ToList();

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = procedureModels;
            return serviceResponse;
        }
        public async Task<ServiceResponse<ProcedureDTO>> GetProcedureById(Int32 id)
        {
            ServiceResponse<ProcedureDTO> serviceResponse = new ServiceResponse<ProcedureDTO>();

            Procedure procedureEntityModel = await _procedureRepository.GetById(id);

            if (procedureEntityModel == null)
            {
                serviceResponse.Message = "Answer is null";
                return serviceResponse;
            }

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = ProcedureMapper.GetProcedureModel(procedureEntityModel);
            return serviceResponse;
        }

        public async Task<ServiceResponse<ProcedureDTO>> AddProcedure(ProcedureDTO procedureModel)
        {
            ServiceResponse<ProcedureDTO> serviceResponse = new ServiceResponse<ProcedureDTO>();
            Boolean isProcedureExists = await _procedureRepository.IsProcedureExistByName(procedureModel.ProcedureName);
            if (isProcedureExists)
            {
                serviceResponse.Message = "Procedure already exist";
                return serviceResponse;
            }

            Procedure procedureEntityModel = ProcedureMapper.GetProcedureAddModel(procedureModel);

            await _procedureRepository.AddProcedure(procedureEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = procedureModel;
            return serviceResponse;
        }
        public async Task<ServiceResponse<ProcedureDTO>> UpdateProcedure(ProcedureDTO procedureModel)
        {
            ServiceResponse<ProcedureDTO> serviceResponse = new ServiceResponse<ProcedureDTO>();

            Boolean isProcedureIdExists = await _procedureRepository.IsProcedureExistById(procedureModel.Id);
            if (!isProcedureIdExists)
            {
                serviceResponse.Message = "Procedure is not exist";
                return serviceResponse;
            }

            Boolean isProcedureNameExists = await _procedureRepository.IsProcedureExistByName(procedureModel.ProcedureName);
            if (isProcedureNameExists)
            {
                serviceResponse.Message = "Procedure already exist";
                return serviceResponse;
            }

            Procedure procedureEntityModel = ProcedureMapper.GetProcedureUpdateModel(procedureModel);

            await _procedureRepository.UpdateProcedure(procedureEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = procedureModel;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Boolean>> DeleteProcedure(Int32 id)
        {
            ServiceResponse<Boolean> serviceResponse = new ServiceResponse<Boolean>();
            Boolean isProcedureExists = await _procedureRepository.IsProcedureExistById(id);

            if (!isProcedureExists)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Procedure is not exist";
                return serviceResponse;
            }

            Procedure procedureEntityModel = new Procedure();
            procedureEntityModel = await _procedureRepository.GetById(id);

            await _procedureRepository.Delete(procedureEntityModel);

            serviceResponse.IsSuccess = true;
            serviceResponse.Data = true;
            return serviceResponse;
        }


    }
}
