using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class OuttakeBatchRepository : Repository<Outtake>, IOuttakeRepository
    {
        public OuttakeBatchRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<OuttakeBatch> FindWithIncludes(Func<OuttakeBatch, bool> func) =>
            _context.OuttakeBatch
                .Include(c => c.Outtakes)
                .Include(c => c.Cook)
                .Where(func).AsQueryable();
    }
}