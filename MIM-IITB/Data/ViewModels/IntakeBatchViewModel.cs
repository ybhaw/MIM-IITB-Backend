using System;
using System.Collections.Generic;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.ViewModels
{
    public class IntakeBatchBaseViewModel
    {
        public decimal TotalBill { get; set; }
        public bool Settled { get; set; }
        public DateTime SettleDate { get; set; }
        public Guid Vendor { get; set; }
    }

    public class IntakeBatchWithAllIncludeViewModel : IntakeBatchBaseViewModel
    {
        public List<IntakeWithAllIncludes> Intakes;
        public VendorBaseViewModel Vendor;
    }
}