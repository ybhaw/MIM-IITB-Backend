using System.Collections.Generic;

namespace MIM_IITB.Data.ViewModels
{
    public class CookBaseViewModel : ViewModelBase
    {
        public string Name { get; set; }
    }

    public class CookViewModel : CookBaseViewModel
    {
        public ICollection<OuttakeBatchViewModel> OuttakeBatches { get; set; }
    }
}