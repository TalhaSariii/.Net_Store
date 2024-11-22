using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
      
        public string? UserName { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public String? Password { get; init; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Password is required.")]
        [Compare("Password",ErrorMessage ="password not match")]

        public String? ConfirmPassword { get; init; }



    }
}