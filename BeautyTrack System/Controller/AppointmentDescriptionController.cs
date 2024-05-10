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
    public class AppointmentDescriptionController : ControllerBase
    {
        private readonly IAppointmentDescriptionService _appointmentService;
        public AppointmentDescriptionController(IAppointmentDescriptionService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetDescriptionByAppointmentId")]
        public async Task<IActionResult> GetByAppointment(Int32 id)
        {
            ServiceResponse<List<AppointmentDescriptionDTO>> response = await _appointmentService.GetByAppointment(id);
            return Ok(response);
        }

        [HttpPost("AddAppointmentDescription")]
        public async Task<IActionResult> AddAppointmentDescription(AppointmentDescriptionViewModel appointmentViewModel)
        {
            ServiceResponse<AppointmentDescriptionDTO> response = await _appointmentService.AddAppointmentDescription(AppointmentDecriptionMapper.GetAppointmentModel(appointmentViewModel));
            return Ok(response);
        }

        [HttpPut("UpdateAppointmentDescription")]
        public async Task<IActionResult> UpdateAppointmentDescription(AppointmentDescriptionViewModel appointmentViewModel)
        {
            ServiceResponse<AppointmentDescriptionDTO> response = await _appointmentService.UpdateAppointmentDescription(AppointmentDecriptionMapper.GetAppointmentModel(appointmentViewModel));
            return Ok(response);
        }

        [HttpDelete("DeleteAppointmentById")]
        public async Task<IActionResult> DeleteAppointmentDescriptionById(Int32 id)
        {
            ServiceResponse<Boolean> response = await _appointmentService.DeleteAppointmentDescription(id);
            return Ok(response);
        }
    }
}
