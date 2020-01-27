using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MIM_IITB.Helpers;

namespace MIM_IITB.Controllers
{
    public class BaseController : ControllerBase
    {
        protected DatabaseContext _context;
        protected IMapper _mapper;

        public BaseController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BaseController(IMapper mapper, DatabaseContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public BaseController(DatabaseContext context)
        {
            _context = context;
        }
    }
}