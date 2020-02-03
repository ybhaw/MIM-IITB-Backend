using System;
using System.Collections.Generic;

namespace MIM_IITB.Data.Requests
{
    public class CookBaseRequest
    {
        public string Name { get; set; }
    }

    public class CookRequest : CookBaseRequest
    {
        public ICollection<OuttakeBatchRequest> OuttakeBatches { get; set; }
    }

    public class CookUpdateRequest : CookRequest
    {
        public Guid Id { get; set; }
    }
}