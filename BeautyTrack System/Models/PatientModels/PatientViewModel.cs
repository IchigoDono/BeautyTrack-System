using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models.PatientModels
{
    public class PatientViewModel
    {
        public Int32? Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public String Name { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public String Surname { get; set; }
        public String Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 10)]
        public String PhoneNumber { get; set; }
    }
}
