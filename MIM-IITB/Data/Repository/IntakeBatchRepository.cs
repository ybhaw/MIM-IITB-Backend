using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class IntakeBatchRepository : Repository<IntakeBatch>, IIntakeBatchRepository
    {
        public IntakeBatchRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<IntakeBatch> FindWithIntakeIncludes(Func<IntakeBatch, bool> predicate) =>
            _context.IntakeBatches
                .Include(c => c.Intakes)
                .Where(predicate).AsQueryable();

        public IQueryable<IntakeBatch> IncludeAll() =>
            _context.IntakeBatches
                .Include(c => c.Intakes)
                .Include(c=>c.Vendor);

        public IQueryable<IntakeBatch> FindWithAllIncludes(Func<IntakeBatch, bool> predicate) =>
            _context.IntakeBatches
                .Include(c=>c.Intakes)
                .Include(c=>c.Vendor)
                .Where(predicate).AsQueryable();
    }
}