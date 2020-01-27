using System.Collections.Generic;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Requests
{
    public class FoodBaseRequest
    {
        public string Name { get; set; }
        public decimal TotalValue { get; set; }
        public bool Expirable { get; set; } = true;
    }

    public class FoodWithDefaultFoodTypeRequest : FoodBaseRequest
    {
        public FoodTypeBaseRequest FoodType { get; set; }
    }

    public class FoodWithMultipleFoodTypeRequest : FoodBaseRequest
    {
        public List<FoodTypeBaseRequest> FoodTypes { get; set; }
    }
}