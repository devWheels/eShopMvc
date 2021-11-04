using Core.Entities;
using Core.Services.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> productService;
        private readonly CategoryService categoryService;
        public ProductService(IRepository<Product> productService, CategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await productService.ListAsync();
        }

        public async Task<Product> Add(Product product)
        {
            var cat = await categoryService.GetCategory();
            cat = from c in cat
                  where product.Categories.Any(p => p.Id == c.Id)
                  select c;
            product.Categories = cat.ToList();

            return await productService.AddAsync(product);
        }
    }
}
