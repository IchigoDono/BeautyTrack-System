using BeautyTrackSystem.BLL.Models.AppointmentDTOs;
using BeautyTrackSystem.DLL.Models.Entities;

namespace BeautyTrackSystem.BLL.Mapper
{
    public class AppointmentMapper
    {
        public static AppointmentDTO GetAppointmenModel(Appointment appointmentEntityModel)
        {
            AppointmentDTO procedureModel = new AppointmentDTO
            {
                Id = appointmentEntityModel.Id,
                Date = appointmentEntityModel.Date,
                FullName = appointmentEntityModel.Patient.Name + " " + appointmentEntityModel.Patient.Surname + " " + appointmentEntityModel.Patient.Patronymic,
                ProcedureName = appointmentEntityModel.Procedure.ProcedureName,
                Price = appointmentEntityModel.Price
            };
            return procedureModel;
        }

        public static Appointment GetAppointmentAddModel(AppointmentAddDTO appointmentAddDTO)
        {
            Appointment appointmentEntityModel = new Appointment
            {
                Date = appointmentAddDTO.Date,
                PatientId = appointmentAddDTO.PatientId,
                ProcedureId = appointmentAddDTO.ProcedureId,
                Price = appointmentAddDTO.Price
            };
            return appointmentEntityModel;
        }
        public static Appointment GetAppointmentUpdateModel(AppointmentAddDTO appointmentAddDTO)
        {
            Appointment appointmentEntityModel = new Appointment
            {
                Id = appointmentAddDTO.Id,
                Date = appointmentAddDTO.Date,
                PatientId = appointmentAddDTO.PatientId,
                ProcedureId = appointmentAddDTO.ProcedureId,
                Price = appointmentAddDTO.Price
            };
            return appointmentEntityModel;
        }
    }
}
