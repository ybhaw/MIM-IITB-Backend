using System;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.ViewModels
{
    public class IntakeBaseViewModel : ViewModelBase
    {
        public DateTime BoughtOn { get; set; } = DateTime.Now;
        public DateTime ExpiresOn { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid FoodId { get; set; }
        public Guid FoodTakeId { get; set; }
        public Guid VendorId { get; set; }
    }

    public class IntakeWithAllIncludes : IntakeBaseViewModel
    {
        public VendorBaseViewModel Vendor;
        public FoodBaseViewModel Food;
        public FoodTypeBaseViewModel FoodType;
    }
}
