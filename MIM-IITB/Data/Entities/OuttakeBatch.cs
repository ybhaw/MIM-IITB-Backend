using System;
using System.Collections.Generic;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Entities
{
    public class OuttakeBatch : EntityBase
    {
        public DateTime Time { get; set; }
        public Constants.Slot Slot { get; set; }
        public Guid CookId { get; set; }
        public virtual Cook Cook { get; set; }
        public ICollection<Outtake> Outtakes { get; set; }
    }
}