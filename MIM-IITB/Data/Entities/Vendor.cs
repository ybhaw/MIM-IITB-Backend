using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MIM_IITB.Data.Entities
{
    public class Vendor : EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public List<Food> Supplies { get; set; } 
        public List<IntakeBatch> Batches { get; set; }

        public Vendor()
        {
            Supplies = new List<Food>();
            Batches = new List<IntakeBatch>();
        }
    }
}