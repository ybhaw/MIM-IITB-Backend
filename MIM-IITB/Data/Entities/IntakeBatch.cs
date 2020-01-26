using System;
using System.Collections.Generic;

namespace MIM_IITB.Data.Entities
{
    public class IntakeBatch : EntityBase
    {
        public List<Intake> Intakes { get; set; }
        public decimal TotalBill { get; set; }
        public bool Settled { get; set; }
        public DateTime SettleDate { get; set; }
    }
}