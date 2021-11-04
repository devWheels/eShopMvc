using Core.Entities;
using Core.Services.Dependency;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace eComerceSana.Infrastructure.Repository
{
	public class MemoryRepository<E> : IRepository<E> where E : Entity
	{
		private IList<Product> product;

		public MemoryRepository()
		{
			if (product == null)
			{
				product = new List<Product>();
			}
		}
		public Task<E> AddAsync(E entity)
		{
			if (typeof(E) == typeof(Product))
			{
				product.Add(entity as Product);
			};
			return Task<E>.Factory.StartNew(() =>
			{
				return entity;
			});
		}

		public Task<IEnumerable<E>> ListAsync()
		{
			IEnumerable<E> returnValue = new HashSet<E>();
			if (typeof(E) == typeof(Product))
			{
				returnValue = (IEnumerable<E>)product;
			};

			return Task<IEnumerable<E>>.Factory.StartNew(() =>
			{
				return returnValue;
			});
		}


	}
}