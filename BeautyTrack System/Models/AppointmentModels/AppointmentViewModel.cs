using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models.AppointmenModels
{
    public class AppointmentViewModel
    {
        public Int32 Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Int32 PatientId { get; set; }
        [Required]
        public Int32 ProcedureId { get; set; }
    }
}
