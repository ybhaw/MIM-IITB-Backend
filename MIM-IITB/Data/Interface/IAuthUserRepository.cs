using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Interface
{
    public interface IAuthUserRepository : IRepository<AuthUser>
    {
        bool IsAuthorized(string token);
        AuthUser GetUser(string token);
        bool RenewToken(string token);
    }
}