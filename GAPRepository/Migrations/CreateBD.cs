using System;
using System.Data.Entity.Migrations;

namespace GAPRepository.Migrations
{
    public class CreateBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Store",
                Store => new
                {
                    Id = Store.Guid(nullable: false),
                    Name = Store.String(),
                    Adress = Store.String()
                })
                .PrimaryKey(s => s.Id);

            CreateTable(
                "dbo.Article",
                Article => new
                {
                    Id = Article.Guid(nullable: false),
                    Name = Article.String(),
                    Description = Article.String(),
                    Price = Article.Double(nullable: false),
                    Total_In_Shelf = Article.Int(nullable: false),
                    Total_In_Vault = Article.Int(nullable: false),
                    StoreId = Article.Guid(nullable: false),
                })
                .PrimaryKey(a => a.Id)
                .ForeignKey("dbo.Store", f => f.StoreId);

        }

        public override void Down()
        {
            DropTable("dbo.Article");
            DropTable("dbo.Store");
        }
    }
}
