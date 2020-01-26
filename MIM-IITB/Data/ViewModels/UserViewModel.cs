using System;

namespace MIM_IITB.Data.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class TokenedUserViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool Remembered { get; set; }
    }
}