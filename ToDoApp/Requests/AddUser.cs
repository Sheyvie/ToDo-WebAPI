using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Requests
{
    public class AddUser
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;
    }
}
