using Core.Entities;
using Core.Services.Dependency;
using eComerceSana.Infrastructure.Repository;
using eComerceSana.Infrastructure.Shared.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eComerceSana.Infrastructure.Shared
{
    public class DataProviderBuilder
    {
        private const string SQL_PROVIDE = "SQL";

        private readonly DbContext dbContext;
        private object memoryRepository;
        public DataProviderBuilder(DbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public IRepository<E> Buil<E>(string source) where E :Entity
        {
            if (string.IsNullOrEmpty(source) || source == SQL_PROVIDE)
            {
                return new GenericRepository<E>(dbContext);
            }
            else
            {
                if(memoryRepository == null)
				{
                    memoryRepository =  new MemoryRepository<E>();
                }
                return (IRepository<E>)memoryRepository;
            }
        }
    }
}