using System;
using System.ComponentModel.DataAnnotations.Schema;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Requests
{
    public class OuttakeBaseRequest
    {
        public decimal Quantity { get; set; }
    }

    public class OuttakeRequest : OuttakeBaseRequest
    {
        [ForeignKey("Food")]
        public Guid FoodId { get; set; }
        public virtual Food Food { get; set; }
        [ForeignKey("OuttakeBatch")]
        public Guid OuttakeBatchId { get; set; }
        public OuttakeBatch OuttakeBatch { get; set; }
    }

    public class OuttakeUpdateRequest : OuttakeRequest
    {
        public Guid Id { get; set; }
    }
}