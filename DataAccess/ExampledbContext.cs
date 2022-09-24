using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExampledbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ExampleDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", "dbo");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("CategoryId");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("ProductName");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("UnitPrice");
            modelBuilder.Entity<Product>().Property(p => p.UnitsInStock).HasColumnName("UnitsInStock");

            modelBuilder.Entity<Category>().ToTable("Categories", "dbo");
            modelBuilder.Entity<Category>().Property(c => c.Id).HasColumnName("CategoryId");
            modelBuilder.Entity<Category>().Property(c => c.CategoryName).HasColumnName("CategoryName");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
