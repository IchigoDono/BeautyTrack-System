using BeautyTrack_System.Mapper;
using BeautyTrack_System.Models.AppointmenModels;
using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.BLL.Models.Responses;
using BeautyTrackSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeautyTrack_System.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetAppointmentByPatient")]
        public async Task<IActionResult> GetAppointmentByPatient(Int32 id)
        {
            ServiceResponse<List<AppointmentDTO>> response = await _appointmentService.GetAppointmentByPatient(id);
            return Ok(response);
        }
        [HttpGet("GetAppointmentList")]
        public async Task<IActionResult> GetAppointmentList(DateTime appointmentDate)
        {
            ServiceResponse<List<AppointmentDTO>> response = await _appointmentService.GetAppointmentList(appointmentDate);
            return Ok(response);
        }

        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment(AppointmentViewModel appointmentViewModel)
        {
            ServiceResponse<AppointmentAddDTO> response = await _appointmentService.AddAppointment(AppointmentMapper.GetAppointmentModel(appointmentViewModel));
            return Ok(response);
        }

        [HttpPut("UpdateAppointment")]
        public async Task<IActionResult> UpdateAppointment(AppointmentViewModel appointmentViewModel)
        {
            ServiceResponse<AppointmentAddDTO> response = await _appointmentService.UpdateProcedure(AppointmentMapper.GetAppointmentModel(appointmentViewModel));
            return Ok(response);
        }

        [HttpDelete("DeleteAppointmentById")]
        public async Task<IActionResult> DeleteAppointmenteById(Int32 id)
        {
            ServiceResponse<Boolean> response = await _appointmentService.DeleteProcedure(id);
            return Ok(response);
        }
    }
}
