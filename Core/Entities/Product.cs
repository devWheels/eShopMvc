using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Product: Entity
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public virtual  ICollection<Category> Categories { get; set; }
    }
}
