using System.ComponentModel.DataAnnotations;

namespace DelivExpress.Api.ModelUser
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Compare("Password", ErrorMessage ="Passwords don´t match")]
        public string ConfirmPassword { get; set;}

    }
}
