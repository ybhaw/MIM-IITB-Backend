using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MIM_IITB.Config;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Models;

namespace MIM_IITB.Data.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : Model
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context) => _context = context;

        private void Save() => _context.SaveChanges();
        private async Task SaveAsync() => await _context.SaveChangesAsync();

        public IEnumerable<TModel> GetAll() => _context.Set<TModel>();

        public IEnumerable<TModel> Find(Func<TModel, bool> predicate) => _context.Set<TModel>().Where(predicate);

        public TModel FindById(Guid id) => _context.Set<TModel>().Find(id);

        public int Count(Func<TModel, bool> predicate) => _context.Set<TModel>().Where(predicate).Count();

        public void Create(TModel entity)
        {
            _context.Add(entity);
            Save();
        }
        public async Task CreateAsync(TModel entity)
        {
            _context.Add(entity);
            await SaveAsync();
        }
        public void Delete(TModel entity)
        {
            _context.Remove(entity);
            Save();
        }
        public async Task DeleteAsync(TModel entity)
        {
            _context.Remove(entity);
            await SaveAsync();
        }
        public void Update(TModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public async Task UpdateAsync(TModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
    }
}