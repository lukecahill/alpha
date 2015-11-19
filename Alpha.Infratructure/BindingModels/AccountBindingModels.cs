using System.ComponentModel.DataAnnotations;

namespace Alpha.Infrastructure.BindingModels {
    public class CreateAccountBindingModels {
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required, StringLength(100, ErrorMessage = "The password must be at least 4 characters long", MinimumLength = 4), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password), Display(Name = "Confirm password"), Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ComparePassword { get; set; }
    }
}
