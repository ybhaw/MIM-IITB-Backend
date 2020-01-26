using System.Collections.Generic;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Helpers
{
    public static class RoleGenerator
    {
        public static List<Role> Generate()
        {
            List<Role> roles = new List<Role>();
            roles.Add(new Role()
            {
                Name = "SuperAdmin",
                Elevation = 0
            });
            roles.Add(new Role()
            {
                Name = "Admin",
                Elevation = 1
            });
            roles.Add(new Role()
            {
                Name = "Council",
                Elevation = 2
            });
            return roles;
        }
    }
}