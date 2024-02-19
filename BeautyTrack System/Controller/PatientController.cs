using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using BeautyTrackSystem.DLL.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTrack_System.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetPatientByPhoneNumber(Int32 id)
        {
            ServiceResponse<PatientEntityModel> response = await _patientService.GetPatientById(id);
            return Ok(response);
        }
        [Authorize]
        [HttpGet("GetPatientList")]
        public async Task<IActionResult> GetPatientList()
        {
            ServiceResponse<List<PatientEntityModel>> response = await _patientService.GetPatientList();
            return Ok(response);
        }

        [HttpDelete("DeletePatientById")]
        public async Task<IActionResult> DeletePatientById(Int32 id)
        {
            ServiceResponse<PatientEntityModel> response = await _patientService.GetPatientById(id);
            return Ok(response);
        }
    }
}
