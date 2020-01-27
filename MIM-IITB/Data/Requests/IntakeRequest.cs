using System;

namespace MIM_IITB.Data.Requests
{
    public class IntakeRequest
    {
        public DateTime BoughtOn { get; set; } = DateTime.Now;
        public DateTime ExpiresOn { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal LeftQuantity { get; set; }
        public Guid FoodTypeId { get; set; }
        public Guid FoodId { get; set; }
        public Guid VendorId { get; set; }
    }

    public class IntakeUpdateRequest : IntakeRequest
    {
        public Guid Id { get; set; }
    }
}