using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MIM_IITB.Data.Entities
{
    public class Cook : EntityBase
    {
        public string Name { get; set; }
        public ICollection<OuttakeBatch> OuttakeBatches { get; set; }
        public Cook() => 
            OuttakeBatches = new List<OuttakeBatch>();
    }
}