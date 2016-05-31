using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SuperZapatosDomainModel;

namespace GAPRepository
{
    public class SuperZapatosContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Article> Articles { get; set; }

        public SuperZapatosContext() : base("SuperZapatosBD")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
