using BeautyTrack_System.Mapper;
using BeautyTrack_System.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.PatientModels;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
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

        [HttpGet("GetPatientByPhone")]
        public async Task<IActionResult> GetPatientByPhoneNumber(String phoneNumber)
        {
            ServiceResponse<PatientModel> response = await _patientService.GetPatientByPhone(phoneNumber);
            return Ok(response);
        }
        [HttpGet("GetPatientList")]
        public async Task<IActionResult> GetPatientList()
        {
            ServiceResponse<List<PatientModel>> response = await _patientService.GetPatientList();
            return Ok(response);
        }

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient(PatientViewModel patientViewModel)
        {
            ServiceResponse<PatientModel> response = await _patientService.AddPatient(PatientMapper.GetPatientModel(patientViewModel));
            return Ok(response);
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(PatientViewModel patientViewModel)
        {
            ServiceResponse<PatientModel> response = await _patientService.UpdatePatient(PatientMapper.GetPatientModel(patientViewModel));
            return Ok(response);
        }

        [HttpDelete("DeletePatientById")]
        public async Task<IActionResult> DeletePatientById(String phoneNumber)
        {
            ServiceResponse<Boolean> response = await _patientService.DeletePatient(phoneNumber);
            return Ok(response);
        }
    }
}
