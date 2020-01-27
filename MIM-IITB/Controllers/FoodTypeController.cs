using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Requests;
using MIM_IITB.Data.ViewModels;
using MIM_IITB.Helpers;

namespace MIM_IITB.Controllers
{
    [ApiController]
    [Route("FoodType")]
    public class FoodTypeController : BaseController
    {
        public IFoodTypeRepository _foodType;
        public FoodTypeController(DatabaseContext context, IMapper mapper, IFoodTypeRepository foodTypeRepository) : base(mapper, context)
        {
            _foodType = foodTypeRepository;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var foodType = _context.FoodTypes.Find(id);
            return Ok(_mapper.Map(foodType, new FoodTypeBaseViewModel()));
        }
    }
}