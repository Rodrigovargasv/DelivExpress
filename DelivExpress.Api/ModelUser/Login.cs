using System.ComponentModel.DataAnnotations;

namespace DelivExpress.Api.Model
{
    public class Login
    {

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [StringLength(20,ErrorMessage = "The {0} must be at least {2} and at max " +
            "{1} characters long", MinimumLength =10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
