using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class AuthUserRepository : Repository<AuthUser>, IAuthUserRepository
    {
        public AuthUserRepository(DatabaseContext context) : base(context)
        {
        }

        public bool IsAuthorized(string token) =>
            _context.AuthUsers.Any(c => c.Token == token && c.ExpiresIn >= DateTime.Now);

        public AuthUser GetUser(string token) =>
            _context.AuthUsers.Include(c=>c.User).ThenInclude(cs=>cs.Roles).First(c => c.Token == token && c.ExpiresIn >= DateTime.Now);

        public bool RenewToken(string token)
        {
            if (IsAuthorized(token))
            {
                var authUser = _context.AuthUsers.FirstOrDefault(c => c.Token == token && c.ExpiresIn >= DateTime.Now);
                if (authUser != null)
                {
                    authUser.ExpiresIn = DateTime.Now;
                    _context.AuthUsers.Update(authUser);
                }
                _context.SaveChanges();
                return true;
            }
            else return false;
        }
        //todo make async RenewToken
    }
}