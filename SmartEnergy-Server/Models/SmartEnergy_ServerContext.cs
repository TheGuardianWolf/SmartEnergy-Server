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
                this.AutomaticMigrationsEnabled = true;
            }
        }

        public System.Data.Entity.DbSet<SmartEnergy_Server.Models.Users> Users { get; set; }
        public System.Data.Entity.DbSet<SmartEnergy_Server.Models.Devices> Devices { get; set; }
        public System.Data.Entity.DbSet<SmartEnergy_Server.Models.Data> Data { get; set; }
    }
}
