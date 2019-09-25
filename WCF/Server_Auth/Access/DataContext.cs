using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Auth.Access
{
    public class DataContext : DbContext
    {
        public DbSet<AppUser> Products { get; set; }
        public DbSet<UserAccount> Accounts { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(ConfigurationManager.ConnectionStrings["app"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Account)
                .WithOne(b => b.User)
                .HasForeignKey<UserAccount>(b => b.UserId);
        }
    }
}
