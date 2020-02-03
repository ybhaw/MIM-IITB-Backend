using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class CookRepository : Repository<Cook>, ICookRepository
    {
        public CookRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<Cook> FindWithIncludes(Func<Cook, bool> predicate) =>
            _context.Cook
                .Include(c => c.OuttakeBatches)
                .Where(predicate).AsQueryable();
    }
}