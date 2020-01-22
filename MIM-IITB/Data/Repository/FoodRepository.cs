using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public FoodRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}