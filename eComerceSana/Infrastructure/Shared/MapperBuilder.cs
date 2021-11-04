using AutoMapper;
using Core.Entities;
using eComerceSana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eComerceSana.Infrastructure.Shared
{
    public class MapperBuilder
    {
        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.AllowNullCollections = true;
                conf.CreateMap<ProductDto, Product>();
                conf.CreateMap<Product, ProductDto>();

                conf.CreateMap<Category, CategoryDto>();
                conf.CreateMap<CategoryDto, Category>();
            });
            return new Mapper(mapperConfig);
        }
    }
}