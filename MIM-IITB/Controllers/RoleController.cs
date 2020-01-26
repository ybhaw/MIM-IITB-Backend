using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Repository;
using MIM_IITB.Helpers;

namespace MIM_IITB.Controllers
{
    [ApiController]
    [Route("Role")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly DatabaseContext _context;
        public RoleController(IRoleRepository role, DatabaseContext context)
        {
            _roleRepository = role;
            _context = context;
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