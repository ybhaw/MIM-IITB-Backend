using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Policies
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute() : base(typeof(AuthFilter))
        {
        }

        public AuthAttribute(string role) : base(typeof(RoleBasedAuthFilter))
        {
            Arguments = new object[] {role};
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
            if(!context.HttpContext.Items.ContainsKey("User")) 
                context.Result = new UnauthorizedResult();
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
            if(!context.HttpContext.Items.ContainsKey("User")) context.Result = new UnauthorizedResult();
            var authUser = (AuthUser) context.HttpContext.Items["User"];
            if (string.IsNullOrEmpty(_role)) return;
            if(authUser.User.Roles.All(c => c.Name != _role))
                context.Result = new UnauthorizedResult();
        }
    }
}