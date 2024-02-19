using System.ComponentModel.DataAnnotations;

namespace BeautyTrack_System.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "Your email is too large")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
