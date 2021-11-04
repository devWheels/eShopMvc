using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Core.Services;
using Core.Services.Dependency;
using eComerceSana.Controllers;
using eComerceSana.Infrastructure.Repository;
using eComerceSana.Infrastructure.Shared;
using eComerceSana.Infrastructure.Shared.Data;
using System.Data.Entity;
using System.Web.Mvc;

namespace eComerceSana.App_Start
{
    public class Dependency
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType(typeof( HomeController) );

            builder.RegisterType<ProductService>();
            builder.RegisterType<CategoryService>();
            
            builder.RegisterType<EcomerceContext>().As<DbContext>().SingleInstance();

            builder.RegisterGeneric(typeof( GenericRepository<>)).As( typeof(IRepository<>) );

            builder.RegisterInstance<IMapper>(MapperBuilder.GetMapper()).SingleInstance();

            builder.RegisterType<DataProviderBuilder>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}