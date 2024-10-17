using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterUserDto
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [MaxLength(30, ErrorMessage = "Max length is 30 characters")]

        public string UserName { get; set; } = string.Empty;

        [MaxLength(30, ErrorMessage = "Max length is 30 characters")]
        public string PassWord { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}