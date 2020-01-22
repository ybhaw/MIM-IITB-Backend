using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIM_IITB.Data.Interface
{
    public interface IRepository<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        IEnumerable<TModel> Find(Func<TModel, bool> predicate);
        TModel FindById(Guid Id);
        void Create(TModel entity);
        Task CreateAsync(TModel entity);
        void Update(TModel entity);
        Task UpdateAsync(TModel entity);
        void Delete(TModel entity);
        Task DeleteAsync(TModel entity);
        int Count(Func<TModel, bool> predicate);
    }
}