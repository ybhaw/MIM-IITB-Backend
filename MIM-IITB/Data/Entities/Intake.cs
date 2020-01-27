using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIM_IITB.Data.Entities
{
    public class Intake : EntityBase
    {
        public DateTime BoughtOn { get; set; } = DateTime.Now;
        public DateTime ExpiresOn { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal LeftQuantity { get; set; }

        [ForeignKey("FoodType")]
        public Guid FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
        
        [ForeignKey("Food")]
        public Guid FoodId { get; set; }
        public Food Food { get; set; }
        
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