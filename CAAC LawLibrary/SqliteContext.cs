using CAAC_LawLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary
{
    public class SqliteContext:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public SqliteContext():base("sqlite")
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Law> Law { get; set; }
    }
}
