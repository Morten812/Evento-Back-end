using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evento_Back_end.Data;
using Evento_Back_end.Contracts;


namespace Evento_Back_end.Repositories
{
    public class BaseAsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AppDbContext context;
        public BaseAsyncRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}


