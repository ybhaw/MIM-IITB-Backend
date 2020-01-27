using System;

namespace MIM_IITB.Data.ViewModels
{
    public class IntakeBaseViewModel : ViewModelBase
    {
        public DateTime BoughtOn { get; set; } = DateTime.Now;
        public DateTime ExpiresOn { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
