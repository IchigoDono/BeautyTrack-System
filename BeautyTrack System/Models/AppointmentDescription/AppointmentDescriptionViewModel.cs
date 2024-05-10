using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models.AppointmenModels
{
    public class AppointmentDescriptionViewModel
    {
        public Int32 Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public Int32 AppointmentId { get; set; }
    }
}
