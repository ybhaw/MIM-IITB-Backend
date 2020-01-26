using System;

namespace MIM_IITB.Data.Entities
{
    public class Intake : EntityBase
    {
        public FoodType FoodType { get; set; }
        public Food Food { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime BoughtOn { get; set; } = DateTime.Now;
        public DateTime ExpiresOn { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal LeftQuantity { get; set; }

        public decimal UseFood(decimal amount)
        {
            if (amount > LeftQuantity)
            {
                amount -= LeftQuantity;
                LeftQuantity = 0;
                return amount;
            }

            LeftQuantity -= amount;
            return 0;
        }
    }
}