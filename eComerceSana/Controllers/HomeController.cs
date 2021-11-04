using AutoMapper;
using Core.Entities;
using Core.Services;
using eComerceSana.Infrastructure.Repository;
using eComerceSana.Infrastructure.Shared;
using eComerceSana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eComerceSana.Controllers
{
	public class HomeController : Controller
	{
		private readonly CategoryService categoryService;
		private readonly IMapper mapper;
		private readonly DataProviderBuilder dataProvider;
		public HomeController(IMapper mapper,
			CategoryService categoryService,
			DataProviderBuilder dataProvider
			)
		{

			this.categoryService = categoryService;
			this.dataProvider = dataProvider;
			this.mapper = mapper;
		}
		public async Task<ActionResult> Index()
		{
			string source = getCookie();
			var service = new ProductService(dataProvider.Buil<Product>(source), categoryService);

			var product = await service.GetProducts();

			var c = product.Select(p => mapper.Map<ProductDto>(p)).ToList();

			return View(c);
		}

		

		public async Task<ActionResult> Product()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Product(ProductDto productDto)
		{
			var product = mapper.Map<Product>(productDto);

			string source = getCookie();
			var service = new ProductService(dataProvider.Buil<Product>(source), categoryService);

			await service.Add(product);

			return View();
		}

		public async Task<ActionResult> Category()
		{
			var category = await categoryService.GetCategory();
			return Json(category.Select(c => mapper.Map<CategoryDto>(c)).ToList(), JsonRequestBehavior.AllowGet);
		}
		private string getCookie()
		{
			var cookie = HttpContext.Request.Cookies.Get("data-provide");
			string source = cookie != null ? cookie.Value : null;
			return source;
		}


	}
}