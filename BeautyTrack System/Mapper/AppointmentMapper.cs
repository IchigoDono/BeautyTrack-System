using BeautyTrack_System.Models.AppointmenModels;
using BeautyTrackSystem.BLL.Models.AppointmentDTOs;

namespace BeautyTrack_System.Mapper
{
    public class AppointmentMapper
    {
        public static AppointmentAddDTO GetAppointmentModel(AppointmentViewModel appointmentViewModel)
        {
            AppointmentAddDTO appointment = new AppointmentAddDTO
            {
                Id = appointmentViewModel.Id,
                Date = appointmentViewModel.Date,
                PatientId = appointmentViewModel.PatientId,
                ProcedureId = appointmentViewModel.ProcedureId,
                Price = appointmentViewModel.Price
            };
            return appointment;
        }
    }
}
