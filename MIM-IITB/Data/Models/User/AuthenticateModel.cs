using System.ComponentModel.DataAnnotations;

namespace MIM_IITB.Data.Models.User
{
    public class AuthenticateModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}