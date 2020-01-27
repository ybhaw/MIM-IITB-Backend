using System;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Repository;
using MIM_IITB.Data.Requests;
using MIM_IITB.Helpers;
using static MIM_IITB.Policies.UserPolicyHelper;

namespace MIM_IITB.Policies
{
    public class AuthAttribute : TypeFilterAttribute
    {
        //authorize if logged in
        public AuthAttribute() : base(typeof(AuthFilter))
        {
        }

        //authorize if role permits to authorize
        public AuthAttribute(string role) : base(typeof(RoleBasedAuthFilter))
        {
            Arguments = new object[] {role};
        }
        
        //authorize if role has given elevation
        public AuthAttribute(int elevation) : base(typeof(ElevationBasedAuthFilter))
        { 
            Arguments = new object[]{elevation};
        }
    }

    internal static class UserPolicyHelper
    {
        public static bool UserExists(AuthorizationFilterContext context)
        {
            return context.HttpContext.Items.ContainsKey("User");
        }

        public static void DenyRequest(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedResult();
        }

        public static AuthUser GetUser(AuthorizationFilterContext context)
        {
            return (AuthUser)context.HttpContext.Items["User"];
        }
    }
    public class AuthFilter : IAuthorizationFilter
    {
       
        private readonly DatabaseContext _context;
        public AuthFilter(DatabaseContext context)
        {
            _context = context;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!UserExists(context)) 
                DenyRequest(context);
        }
    }

    public class RoleBasedAuthFilter : IAuthorizationFilter
    {
        private readonly DatabaseContext _context;
        private readonly string _role;

        public RoleBasedAuthFilter(DatabaseContext context, string role)
        {
            _context = context;
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!UserExists(context)) 
                DenyRequest(context);
            else
            {
                var authUser = GetUser(context);
                if (authUser.User.Roles.Any(c => c.Elevation == 0)) return;
                if (string.IsNullOrEmpty(_role)) return;
                if(!authUser.User.HasRole(_role))
                    DenyRequest(context); 
            }
            
        }
    }

    public class ElevationBasedAuthFilter : IAuthorizationFilter
    {
        private readonly int _elevation;
        private readonly DatabaseContext _context;
        public ElevationBasedAuthFilter(int elevation, DatabaseContext context)
        {
            _elevation = elevation;
            _context = context;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!UserExists(context)) DenyRequest(context);
            else
            {
                var authUser = GetUser(context);
                if (authUser.User.Roles.Any(c => c.Elevation <= _elevation)) return;
            }
            DenyRequest(context);                
        }
    }
}