using Core.Common.Contracts;
using HN.Wow.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HN.Wow.Data
{
    public class WowContext : DbContext
    {
        public WowContext()
            : base("name=DevHNWowDb")
        {
            Database.SetInitializer<WowContext>(null);
        }

        public DbSet<Product> ProductSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Product>().HasKey<int>(e => e.ProductId).Ignore(e => e.EntityId);
        }
    }
}
