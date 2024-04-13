using BeautyTrack_System.Mapper;
using BeautyTrack_System.Models.ProcedureModels;
using BeautyTrackSystem.BLL.Models.ProcedureDTOs;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTrack_System.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;
        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpGet("GetProcedureById")]
        public async Task<IActionResult> GetProcedureById(Int32 id)
        {
            ServiceResponse<ProcedureDTO> response = await _procedureService.GetProcedureById(id);
            return Ok(response);
        }
        [HttpGet("GetProcedureList")]
        public async Task<IActionResult> GetProcedureList()
        {
            ServiceResponse<List<ProcedureDTO>> response = await _procedureService.GetProcedureList();
            return Ok(response);
        }

        [HttpPost("AddProcedure")]
        public async Task<IActionResult> AddProcedure(ProcedureViewModel procedureViewModel)
        {
            ServiceResponse<ProcedureDTO> response = await _procedureService.AddProcedure(ProcedureMapper.GetProcedureModel(procedureViewModel));
            return Ok(response);
        }

        [HttpPut("UpdateProcedure")]
        public async Task<IActionResult> UpdateProcedure(ProcedureViewModel procedureViewModel)
        {
            ServiceResponse<ProcedureDTO> response = await _procedureService.UpdateProcedure(ProcedureMapper.GetProcedureModel(procedureViewModel));
            return Ok(response);
        }

        [HttpDelete("DeleteProcedureById")]
        public async Task<IActionResult> DeleteProcedureById(Int32 id)
        {
            ServiceResponse<Boolean> response = await _procedureService.DeleteProcedure(id);
            return Ok(response);
        }
    }
}
