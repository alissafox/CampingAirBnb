using System.ComponentModel.DataAnnotations;

namespace Camping.Models
{
    public class LogInUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
