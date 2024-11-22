using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; init; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; init; }

        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}
