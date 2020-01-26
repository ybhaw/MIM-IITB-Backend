using System.Collections.Generic;

namespace MIM_IITB.Data.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public int Elevation { get; set; }
        public List<RoleGroup> RoleGroups { get; set; }
    }
    public class RoleGroup : EntityBase
    {
        public string Name { get; set; }
        public List<Role> Roles;
    }
}