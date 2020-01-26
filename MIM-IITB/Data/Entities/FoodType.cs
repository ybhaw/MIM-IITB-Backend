using System.Collections.Generic;

namespace MIM_IITB.Data.Entities
{
    public class FoodType : EntityBase
    {
        public string Name { get; set; }
        public Food Food { get; set; }
        public bool Expirable { get; set; } = false;
        public decimal Value { get; set; }
        public List<Intake> Intakes { get; set; }

        public FoodType()
        {
            Intakes = new List<Intake>();
        }
    }
}