using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIM_IITB.Data.Entities
{
    public class FoodType : EntityBase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public bool Expirable { get; set; } = false;
        public decimal Value { get; set; }
        
        [ForeignKey("Food")]
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
        
        public List<Intake> Intakes { get; set; }

        public FoodType()
        {
            Intakes = new List<Intake>();
        }
    }
}