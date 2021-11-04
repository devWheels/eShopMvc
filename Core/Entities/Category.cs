using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Category: Entity
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
