namespace MIM_IITB.Data.Requests
{
    public class RegisterUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUser
    {
        public string Name { get; set; }
        public string UpdatedName { get; set; }
        public string Email { get; set; }
        public string UpdatedEmail { get; set; }
        public string CurrentPassword { get; set; }
        public string UpdatedPassword { get; set; }
    }

    public class AuthenticateUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; } = false;
    }
}