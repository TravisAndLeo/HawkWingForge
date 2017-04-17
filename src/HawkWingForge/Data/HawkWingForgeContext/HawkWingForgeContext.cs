using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HawkWingForge.Models;

namespace HawkWingForge.Data
{
    public class HawkWingForgeContext : DbContext
    {
        public HawkWingForgeContext(DbContextOptions<HawkWingForgeContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        //Makes tables have singular names
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductType>().ToTable("ProductType");
        }
    }
}