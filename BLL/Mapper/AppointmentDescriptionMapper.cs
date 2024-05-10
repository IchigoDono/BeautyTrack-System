using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class AppointmentDescriptionMapper
    {
        public static AppointmentDescriptionDTO GetAppointmentModel(AppointmentDescription appointmentEntityModel)
        {
            AppointmentDescriptionDTO procedureModel = new AppointmentDescriptionDTO
            {
                Id = appointmentEntityModel.Id,
                Date = appointmentEntityModel.Date,
                Description = appointmentEntityModel.Description,
                AppointmentId = appointmentEntityModel.AppointmentId
                
            };
            return procedureModel;
        }

        public static AppointmentDescription GetAppointmentAddModel(AppointmentDescriptionDTO appointmentAddDTO)
        {
            AppointmentDescription appointmentEntityModel = new AppointmentDescription
            {
                Date = appointmentAddDTO.Date,
                Description = appointmentAddDTO.Description,
                AppointmentId = appointmentAddDTO.AppointmentId
            };
            return appointmentEntityModel;
        }

        public static AppointmentDescription GetAppointmentUpdateModel(AppointmentDescriptionDTO appointmentAddDTO)
        {
            AppointmentDescription appointmentEntityModel = new AppointmentDescription
            {
                Id = appointmentAddDTO.Id,
                Date = appointmentAddDTO.Date,
                Description = appointmentAddDTO.Description,
                AppointmentId = appointmentAddDTO.AppointmentId
            };
            return appointmentEntityModel;
        }
    }
}
