using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChampSupermarket.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ChampSupermarket.DAL
{
    public class SupermarketContext: DbContext
    {
        public SupermarketContext() : base("SupermarketContext")
        {

        }
        
        public DbSet<Product> products { get; set; }
        public DbSet<Suplier> supliers { get; set; }
        public DbSet<Client> clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
 }
