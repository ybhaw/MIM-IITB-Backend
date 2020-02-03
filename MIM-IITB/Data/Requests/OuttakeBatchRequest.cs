using System;
using System.Collections.Generic;
using MIM_IITB.Data.Entities;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Requests
{
    public class OuttakeBatchBaseRequest
    {
        public DateTime Time { get; set; }
        public Constants.Slot Slot { get; set; }
        
    }
    public class OuttakeBatchRequest : OuttakeBatchBaseRequest
    {
        public Guid CookId { get; set; }
        public virtual Cook Cook { get; set; }
        public ICollection<Outtake> Outtakes { get; set; }
    }

    public class OuttakeBatchUpdateRequest : OuttakeBatchRequest
    {
        public Guid Id { get; set; }
    }
}