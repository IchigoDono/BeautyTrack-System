using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models.AuthModels
{
    public class RestorePasswordViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "Your email is too large")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
