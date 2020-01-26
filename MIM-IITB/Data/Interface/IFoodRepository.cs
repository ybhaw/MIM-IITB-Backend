using System;
using System.Linq;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Interface
{
    public interface IFoodRepository : IRepository<Food>
    {
        //todo Add if expired and other functions
        IQueryable<Food> FindWithIncludes(Func<Food, bool> predicate);
    }
}