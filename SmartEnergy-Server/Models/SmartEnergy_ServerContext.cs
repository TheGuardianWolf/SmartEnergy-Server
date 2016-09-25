using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SmartEnergy_Server.Models
{
    public class SmartEnergy_ServerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SmartEnergy_ServerContext() : base("name=SmartEnergy_ServerContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SmartEnergy_ServerContext, DbConfiguration>());
        }

        public class DbConfiguration : DbMigrationsConfiguration<SmartEnergy_ServerContext>
        {
            public DbConfiguration()
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>().Property(Data => Data.Value).HasPrecision(18, 5);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Data> Data { get; set; }
        // public IQueryable<Device> Devices { get; internal set; }
    }
}
