using System;

namespace MIM_IITB.Data.Entities
{
    public class AuthUser : EntityBase
    {
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; } = DateTime.Now.AddHours(7);
        public int RenewCounter { get; set; } = 0;
        public bool Remember { get; set; } = false;
        public AuthUser(User user, string token, bool remember = false)
        {
            this.User = user;
            this.Token = token;
            this.Remember = remember;
            if (remember) ExpiresIn = DateTime.Now.AddDays(30);
        }

        public AuthUser()
        {
            
        }
    }
}