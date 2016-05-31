using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using SuperZapatosDomainModel;

namespace GAPRepository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GAPRepository.SuperZapatosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GAPRepository.SuperZapatosContext context)
        {
            context.Stores.AddOrUpdate(p=>p.Id,
              new Store { Name = "Store 1", Id = new Guid("e14e13d2-729f-4dc0-9ae3-798f5e96dd61"), Adress = "Adress 1" },
              new Store { Name = "Store 2", Id = new Guid("e14e13d2-729f-4dc0-9ae3-798f5e96dd62"), Adress = "Adress 2" },
              new Store { Name = "Store 3", Id = new Guid("e14e13d2-729f-4dc0-9ae3-798f5e96dd63"), Adress = "Adress 3" }
            );

            context.Articles.AddOrUpdate(p => p.Id,
              new Article { Name = "Article 1", Id = new Guid("a14e13d2-729f-4dc0-9ae3-798f5e96dd61"), Description = "Description 1", Price = 100, StoreId = new Guid("e14e13d2-729f-4dc0-9ae3-798f5e96dd61"), Total_In_Shelf = 2, Total_In_Vault = 10 },
              new Article { Name = "Article 2", Id = new Guid("a14e13d2-729f-4dc0-9ae3-798f5e96dd62"), Description = "Description 2", Price = 100, StoreId = new Guid("e14e13d2-729f-4dc0-9ae3-798f5e96dd61"), Total_In_Shelf = 2, Total_In_Vault = 14 },
              new Article { Name = "Article 3", Id = new Guid("a14e13d2-729f-4dc0-9ae3-798f5e96dd63"), Description = "Description 3", Price = 100, StoreId = new Guid("e14e13d2-729f-4dc0-9ae3-798f5e96dd62"), Total_In_Shelf = 2, Total_In_Vault = 13 }
            );
            
        }
    }
}