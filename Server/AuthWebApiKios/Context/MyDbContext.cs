using AuthWebApiKios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthWebApiKios.Context
{
    public class MyDbContext : DbContext
    {

        public MyDbContext()
            : base("AuthWebApiDb")
        {
            Database.SetInitializer<MyDbContext>(new MyDbInitializer());
        }

        public DbSet<User> Users { get; set; }

    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //  modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}