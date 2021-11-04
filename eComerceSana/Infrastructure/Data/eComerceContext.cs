using Core.Entities;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace eComerceSana.Infrastructure.Shared.Data
{
    public class EcomerceContext : DbContext
    {
        public EcomerceContext():base("sanaConection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasMany<Category>(c => c.Categories)
                .WithMany(p => p.Products)
                .Map(pc =>
                {
                    pc.MapLeftKey("IdProduct");
                    pc.MapRightKey("IdCategory");
                    pc.ToTable("ProductCategory");
                    
                });
        }
    }
}
