using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Requests;
using MIM_IITB.Data.ViewModels;
using MIM_IITB.Helpers;
using MIM_IITB.Policies;

namespace MIM_IITB.Controllers
{
    [ApiController]
    [Route("Food")]
    public class FoodController : BaseController
    {
        private IFoodRepository _foodRepository;

        public FoodController(IFoodRepository foodRepository, IMapper mapper, DatabaseContext context) : base(context,mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        { 
            return Ok(_foodRepository.FindWithIncludes(c=>true));
        }

        [HttpGet("User")]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        [Auth(2)]
        public IActionResult Post([FromBody]FoodWithDefaultFoodTypeRequest foodRequest)
        {
            Food food = _mapper.Map(foodRequest, new Food());
            _foodRepository.Create(food);
            return Ok(_mapper.Map(_foodRepository.FindWithIncludes(c => c.Id == food.Id),
                new FoodWithFoodTypesViewModel()));
        }

        [HttpPost("WithFoodType")]
        [Auth(2)]
        public IActionResult Post([FromBody] FoodWithMultipleFoodTypeRequest foodRequest)
        {
            Food food = _mapper.Map(foodRequest, new Food());
            _foodRepository.Create(food);
            return Ok(_mapper.Map(_foodRepository.FindWithIncludes(c=>c.Id == food.Id),
                new FoodWithFoodTypesViewModel()
                ));
        }

        [HttpPut]
        [Auth(2)]
        public IActionResult Put([FromBody] FoodWithDefaultFoodTypeRequest foodRequest)
        {
            Food food = _mapper.Map(foodRequest, new Food());
            _foodRepository.Update(food);
            return Ok(_foodRepository.FindWithIncludes(c => c.Id == food.Id));
        }

        [HttpDelete("{id}")]
        [Auth(2)]
        public IActionResult Delete(Guid id)
        {
            var food = _foodRepository.FindById(id);
            _foodRepository.Delete(food);
            return Ok();
        }

        [HttpDelete("Range")]
        [Auth(2)]
        public IActionResult Delete(List<Guid> ids)
        {
            _context.Foods.RemoveRange(_context.Foods.Where(c=>ids.Contains(c.Id)));
            return Ok();
        }
    }
}