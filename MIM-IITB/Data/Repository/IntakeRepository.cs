using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class IntakeRepository : Repository<Intake>, IIntakeRepository
    {
        public IntakeRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<Intake> FindWithIncludes(Func<Intake, bool> predicate) =>
            _context.Intakes
                .Include(c => c.Food)
                .Include(c => c.FoodType)
                .Where(predicate).AsQueryable();
    }
}