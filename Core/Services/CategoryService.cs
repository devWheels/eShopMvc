using Core.Entities;
using Core.Services.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository )
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await categoryRepository.ListAsync();
        }
    }
}
