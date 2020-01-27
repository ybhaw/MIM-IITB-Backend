using System.Collections.Generic;

namespace MIM_IITB.Data.ViewModels
{
    public class FoodBaseViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public decimal TotalValue { get; set; }
        public bool Expirable { get; set; } = false;
    }

    public class FoodWithFoodTypesViewModel : FoodBaseViewModel
    {
        public List<FoodTypeBaseViewModel> FoodTypes;
    }

    public class FoodWithIntakeViewModel : FoodBaseViewModel
    {
        //todo make intake view model
    }

    public class FoodWithIncludeViewModel : FoodBaseViewModel
    {
        //todo make includes
    }
}