using System;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Requests
{
    public class FoodTypeBaseRequest
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public bool Expirable { get; set; }
        public decimal Value { get; set; }
    }

    public class FoodTypeWithFoodIdRequest : FoodTypeBaseRequest
    {
        public Guid FoodId { get; set; }
    }
    public class FoodTypeWithFoodRequest : FoodTypeBaseRequest
    {
        public FoodBaseRequest Food { get; set; }
    }
    public class FoodTypeUpdateRequest : FoodTypeBaseRequest
    {
        public Guid Id { get; set; }
        public Guid FoodId { get; set; }
    }
}