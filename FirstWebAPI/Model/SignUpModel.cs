using System.ComponentModel.DataAnnotations;

namespace FirstWebAPI.Model
{
    public class SignUpModel
    {
        [Required]
        public string firstName { get; set; } = null!;
        [Required]
        public string lastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
