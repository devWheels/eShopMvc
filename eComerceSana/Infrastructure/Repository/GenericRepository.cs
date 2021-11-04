using Core.Entities;
using Core.Services.Dependency;
using eComerceSana.Infrastructure.Shared.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace eComerceSana.Infrastructure.Repository
{
    public class GenericRepository<E> : IRepository<E> where E: Entity
    {
        private readonly DbContext dbContext;

        public GenericRepository(DbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public async Task<E> AddAsync(E entity)
        {
            if (entity != null)
            {
                var item = dbContext.Set<E>();
                item.Add(entity);
                await dbContext.SaveChangesAsync();
            }
            return entity;
        }

       
        public async Task<IEnumerable<E>> ListAsync()
        {
            return await dbContext.Set<E>().ToListAsync();
        }
    }
}
