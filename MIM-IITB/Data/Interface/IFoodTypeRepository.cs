using System;
using System.Linq;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Interface
{
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        IQueryable<FoodType> FindWithIncludes(Func<FoodType,bool> predicate);
    }
}