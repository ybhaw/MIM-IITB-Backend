using System;
using System.Linq;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Interface
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        IQueryable<Vendor> FindWithIncludes(Func<Vendor, bool> predicate);
    }
}