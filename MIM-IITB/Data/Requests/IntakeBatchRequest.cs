using System;
using System.Collections.Generic;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Requests
{
    public class IntakeBatchBaseRequest
    {
        public decimal TotalBill { get; set; }
        public bool Settled { get; set; }
        public DateTime SettleDate { get; set; }
        public Guid VendorId { get; set; }
    }

    public class IntakeBatchRequest : IntakeBatchBaseRequest
    {
        public List<IntakeRequest> IntakeRequests { get; set; }
        public Vendor Vendor { get; set; }
    }

    public class IntakeBatchUpdateRequest : IntakeBatchRequest
    {
        public Guid Id;
    }
}