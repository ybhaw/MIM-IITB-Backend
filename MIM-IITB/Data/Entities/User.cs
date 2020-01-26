using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MIM_IITB.Data.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public List<Role> Roles { get; set; } = new List<Role>();
        public bool HasRole(Role role) => this.Roles.Contains(role);
    }
}