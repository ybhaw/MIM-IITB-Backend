using System;
using System.Collections.Generic;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Requests;

namespace MIM_IITB.Data.ViewModels
{
    public class FoodTypeBaseViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public bool Expirable { get; set; } = false;
        public decimal Value { get; set; }
    }

    public class FoodTypeWithFoodViewModel : FoodTypeBaseViewModel
    {
        public FoodBaseViewModel Food { get; set; }
    }

    public class FoodTypeWithFoodIdViewModel : FoodTypeBaseViewModel
    {
        public Guid FoodId { get; set; }
    }
}