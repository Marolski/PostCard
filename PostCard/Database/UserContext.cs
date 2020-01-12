using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PostCard.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PostCard.Database
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {
        }
        public DbSet<UserDb> UserDb { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}