using BeautyTrack_System.Models.AppointmenModels;
using BeautyTrackSystem.BLL.Models.AppointmentDTOs;

namespace BeautyTrack_System.Mapper
{
    public class AppointmentDecriptionMapper
    {
        public static AppointmentDescriptionDTO GetAppointmentModel(AppointmentDescriptionViewModel appointmentViewModel)
        {
            AppointmentDescriptionDTO appointment = new AppointmentDescriptionDTO
            {
                Id = appointmentViewModel.Id,
                Date = appointmentViewModel.Date,
                Description = appointmentViewModel.Description,
                AppointmentId = appointmentViewModel.AppointmentId
            };
            return appointment;
        }
    }
}
