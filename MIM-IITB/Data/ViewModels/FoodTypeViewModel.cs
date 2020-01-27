using System.Collections.Generic;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.ViewModels
{
    public class FoodTypeBaseViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public bool Expirable { get; set; } = false;
        public decimal Value { get; set; }
    }
}