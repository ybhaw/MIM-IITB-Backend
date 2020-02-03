using System;
using System.Collections.Generic;
using MIM_IITB.Data.Entities;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.ViewModels
{
    public class OuttakeBatchBaseViewModel : ViewModelBase
    {
        public DateTime Time { get; set; }
        public Constants.Slot Slot { get; set; }

    }
    public class OuttakeBatchViewModel : OuttakeBatchBaseViewModel
    {
        public CookBaseViewModel Cook { get; set; }
        public ICollection<OuttakeWithFoodOnlyViewModel> Outtakes { get; set; }
    }
}