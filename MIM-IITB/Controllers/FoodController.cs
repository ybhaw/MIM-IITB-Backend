using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MIM_IITB.Data.Interface;

namespace MIM_IITB.Controllers
{
    public class FoodController : ControllerBase
    {
        private IFoodRepository _foodRepository;

        public FoodController(IFoodRepository foodRepository)
        {
            this._foodRepository = foodRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        { 
            return Ok(_foodRepository.GetAll());
        }
    }
}