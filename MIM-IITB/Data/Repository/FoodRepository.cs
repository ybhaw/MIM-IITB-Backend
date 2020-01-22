using MIM_IITB.Config;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Models;

namespace MIM_IITB.Data.Repository
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public FoodRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}