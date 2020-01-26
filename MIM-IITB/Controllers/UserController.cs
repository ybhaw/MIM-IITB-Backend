using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Requests;
using MIM_IITB.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Helpers;
using MIM_IITB.Policies;

namespace MIM_IITB.Controllers
{
    
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly IUserRepository _user;
        protected readonly IAuthUserRepository _authUser;
        protected readonly DatabaseContext _context;

        public UserController(IMapper mapper, IUserRepository userRepository, IAuthUserRepository authUser, DatabaseContext context)
        {
            this._mapper = mapper;
            this._user = userRepository;
            this._authUser = authUser;
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            User user = new User();
            _mapper.Map(registerUser, user);
            await _user.CreateAsync(user);
            user = _user.Find(u => u.Email == user.Email).FirstOrDefault();
            
            return Ok(_mapper.Map(user,new UserViewModel()));
        }

        [HttpGet]
        public async Task<List<UserViewModel>> Users() =>
            await _user.GetAll().Select(c => _mapper.Map(c, new UserViewModel())).ToListAsync();

        [HttpGet("{id}")]
        public UserViewModel Get(Guid id) =>
            _mapper.Map(_user.FindById(id), new UserViewModel());

        [HttpPut]
        public UserViewModel Put(Guid id, [FromBody] UpdateUser updateUser)
        {
            var user = _user.FindById(id);
            _mapper.Map(updateUser, user);
            _user.Update(user);
            return _mapper.Map(_user.FindById(id), new UserViewModel());
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateUser authenticateUser)
        {
            var queryable = _user.Find(c =>
                c.Email == authenticateUser.Email && Authentication.ValidateUser(c, authenticateUser.Password));
            if(!queryable.Any()) return BadRequest();
            else
            {
                User user = queryable.FirstOrDefault();
                string token = Authentication.GenerateToken(user);
                AuthUser authUser = new AuthUser(user,token, authenticateUser.Remember);
                _context.RemoveRange(_context.AuthUsers.Where(c => c.User == user));
                _context.AuthUsers.Add(authUser);
                _context.SaveChanges();
                return Ok(_mapper.Map(authUser, new TokenedUserViewModel()));
            }
        }
        [HttpDelete("Delete/{id}")]
        public void Delete(Guid id) =>
            _user.Delete(_user.FindById(id));
    }
}