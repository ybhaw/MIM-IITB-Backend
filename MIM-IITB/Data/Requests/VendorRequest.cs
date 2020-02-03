using System;
using System.Collections;
using System.Collections.Generic;
using MIM_IITB.Data.ViewModels;

namespace MIM_IITB.Data.Requests
{
    public class VendorBaseRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class VendorWithAllIncludesRequest : VendorBaseRequest
    {
        public ICollection<FoodTypeBaseViewModel> FoodTypes { get; set; }
        public ICollection<IntakeBatchRequest> IntakeBatches { get; set; }
    }

    public class VendorUpdateRequest : VendorWithAllIncludesRequest
    {
        public Guid Id { get; set; }
    }
}