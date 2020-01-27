using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIM_IITB.Data.Entities
{
    public class IntakeBatch : EntityBase
    {
        public List<Intake> Intakes { get; set; }
        public decimal TotalBill { get; set; }
        public bool Settled { get; set; }
        public DateTime SettleDate { get; set; }

        [ForeignKey("Vendor")]
        public Guid VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}