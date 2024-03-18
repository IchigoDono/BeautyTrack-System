using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models.PatientModels
{
    public class PatientViewModel
    {
        public Int32? Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateOnly Birthday { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string PhomeNumber { get; set; }
    }
}
