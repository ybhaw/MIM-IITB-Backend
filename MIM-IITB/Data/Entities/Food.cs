using System.Collections.Generic;

namespace MIM_IITB.Data.Entities
{
    public class Food : EntityBase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal TotalValue { get; set; }
        public bool Expirable { get; set; } = false;
        public List<FoodType> FoodTypes { get; set; }
        public List<Intake> Inventories { get; set; }

        public Food()
        {
            FoodTypes = new List<FoodType>();
            Inventories = new List<Intake>();
        }
    }
}