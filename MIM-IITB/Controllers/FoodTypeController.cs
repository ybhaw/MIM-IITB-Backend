using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Requests;
using MIM_IITB.Data.ViewModels;
using MIM_IITB.Helpers;
using MIM_IITB.Policies;

namespace MIM_IITB.Controllers
{
    [ApiController]
    [Route("FoodType")]
    public class FoodTypeController : BaseController
    {
        public IFoodTypeRepository _foodType;

        public FoodTypeController(DatabaseContext context, IMapper mapper, IFoodTypeRepository foodTypeRepository) :
            base(mapper, context)
        {
            _foodType = foodTypeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.FoodTypes.Select(c => _mapper.Map(c, new FoodTypeBaseViewModel())));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_mapper.Map(
                _context.FoodTypes.Include(c => c.Food).First(c=>c.Id == id),
                new FoodTypeWithFoodViewModel()));
        }

        [HttpGet("Food/{id}")]
        public IActionResult GetByFoodId(Guid id)
        {
            var foodTypes = _context.FoodTypes.Include(c=>c.Food).First(c => c.Food.Id == id);
            return Ok(_mapper.Map(foodTypes, new FoodTypeBaseViewModel()));
        }

        [HttpPost]
        [Auth(2)]
        public IActionResult Post(FoodTypeWithFoodIdRequest foodTypeRequest)
        {
            var foodType = _mapper.Map(foodTypeRequest,new FoodType());
            _context.FoodTypes.Add(foodType);
            _context.SaveChanges();
            return Ok(_mapper.Map(foodType,new FoodTypeWithFoodIdViewModel()));
        }

        [HttpPut]
        [Auth(2)]
        public IActionResult Put(FoodTypeUpdateRequest foodTypeRequest)
        {
            var foodType = _context.FoodTypes.Find(foodTypeRequest.Id);
            _context.FoodTypes.Update(_mapper.Map(foodTypeRequest, foodType));
            _context.SaveChanges();
            return Ok(_mapper.Map(foodType, new FoodTypeWithFoodIdViewModel()));
        }

        [HttpDelete("{id}")]
        [Auth(2)]
        public IActionResult Delete(Guid id)
        {
            _context.Remove(_context.FoodTypes.Find(id));
            _context.SaveChanges();
            return Ok();
        }
    }
}