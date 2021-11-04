namespace eComerceSana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        IdProduct = c.Int(nullable: false),
                        IdCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProduct, t.IdCategory })
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.IdCategory, cascadeDelete: true)
                .Index(t => t.IdProduct)
                .Index(t => t.IdCategory);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.ProductCategory", "IdProduct", "dbo.Products");
            DropIndex("dbo.ProductCategory", new[] { "IdCategory" });
            DropIndex("dbo.ProductCategory", new[] { "IdProduct" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
        }
    }
}
