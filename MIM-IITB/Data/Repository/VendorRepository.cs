using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Helpers;

namespace MIM_IITB.Data.Repository
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(DatabaseContext context) : base(context)
        {
        }

        public IQueryable<Vendor> FindWithIncludes(Func<Vendor, bool> predicate) =>
            _context.Vendors
                .Include(c => c.Supplies)
                .Include(c => c.Batches)
                .Where(predicate).AsQueryable();
    }
}