using System.Collections;
using System.Collections.Generic;

namespace MIM_IITB.Data.ViewModels
{
    public class VendorBaseViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
    public class VendorWithAllIncludesViewModel : VendorBaseViewModel
    {
        public ICollection<FoodTypeBaseViewModel> Foods { get; set; }
        public ICollection<IntakeBatchWithAllIncludeViewModel> IntakeBatches { get; set; }
    }
}