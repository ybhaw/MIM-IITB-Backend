using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Repository;
using MIM_IITB.Helpers;

namespace MIM_IITB.Controllers
{
    [ApiController]
    [Route("Role")]
    public class RoleController : BaseController
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository role, DatabaseContext context) : base(context)
        {
            _roleRepository = role;
        }
        
        [HttpGet]
        public ObjectResult Generate()
        {
            var presentRoles = _roleRepository.GetAll().ToList();
            var roles = RoleGenerator.Generate();
            var notPresentRoles = roles.Where(c => presentRoles.All(cc => cc.Name != c.Name)).ToList();
            _context.Roles.AddRange(notPresentRoles);
            _context.SaveChanges();
            return new ObjectResult(_context.Roles);
        }
    }
}