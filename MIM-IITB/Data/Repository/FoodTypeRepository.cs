using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        public FoodTypeRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<FoodType> FindWithIncludes(Func<FoodType, bool> predicate) => 
            _context.FoodTypes
                .Include(c => c.Intakes)
                .Include(c => c.Food)
                .Where(predicate).AsQueryable();
    }
}