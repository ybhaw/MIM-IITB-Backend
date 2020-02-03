using System;
using System.ComponentModel.DataAnnotations.Schema;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Entities
{
    public class Outtake : EntityBase
    {
        public decimal Quantity { get; set; }
        [ForeignKey("Food")]
        public Guid FoodId { get; set; }
        public virtual Food Food { get; set; }
        [ForeignKey("OuttakeBatch")]
        public Guid OuttakeBatchId { get; set; }
        public OuttakeBatch OuttakeBatch { get; set; }
    }
}