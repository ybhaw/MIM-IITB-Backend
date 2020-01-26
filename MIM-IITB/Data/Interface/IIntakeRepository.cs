using System;
using System.Linq;
using MIM_IITB.Data.Entities;

namespace MIM_IITB.Data.Interface
{
    public interface IIntakeRepository : IRepository<Intake>
    {
        IQueryable<Intake> FindWithIncludes(Func<Intake, bool> predicate);
    }
}