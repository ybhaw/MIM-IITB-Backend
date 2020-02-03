using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class OuttakeRepository : Repository<Outtake>, IOuttakeRepository
    {
        public OuttakeRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<Outtake> FindWithIncludes(Func<Outtake, bool> predicate) =>
            _context.Outtake.Include(c => c.Food)
                .Include(c => c.OuttakeBatch)
                .Where(predicate).AsQueryable();
    }
}