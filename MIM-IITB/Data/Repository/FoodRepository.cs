using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Food> FindWithIncludes(Func<Food, bool> predicate) =>
            _context.Foods
                .Include(c => c.FoodTypes)
                .Include(c=>c.Inventories)
                .Where(predicate).AsQueryable();
    }
}