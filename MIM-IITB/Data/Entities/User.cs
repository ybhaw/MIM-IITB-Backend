using System.ComponentModel.DataAnnotations;

namespace MIM_IITB.Data.Entities
{
    public class User : Model
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}