using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_Infrastructre.Interfaces;

namespace TVManager_Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public readonly TVManagerDBContext context;
        private DbSet<T> table;
        public GenericRepository()
        {
            context = new TVManagerDBContext();
            table = context.Set<T>();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            var entityEntry = await context.AddAsync(entity);
            await Save();
            return entityEntry.Entity;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            var entityEntry = context.Remove(entity);
            await Save();
            return entityEntry.Entity;
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await table.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var entityEntry = context.Update(entity);
            await Save();
            return entityEntry.Entity;
        }
    }
}
