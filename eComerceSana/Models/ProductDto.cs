using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eComerceSana.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public ICollection<CategoryDto> Categories { get; set; }
    }
}