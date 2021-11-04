using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Dependency
{
    public interface IRepository<E> where E : Entity
    {
        Task<IEnumerable<E>> ListAsync();
        Task<E> AddAsync(E entity);
    }
}
