using System;
using System.Linq;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Interface
{
    public interface IIntakeBatchRepository : IRepository<IntakeBatch>
    {
        IQueryable<IntakeBatch> IntakeBatches(Func<IntakeBatch, bool> predicate);
    }
}