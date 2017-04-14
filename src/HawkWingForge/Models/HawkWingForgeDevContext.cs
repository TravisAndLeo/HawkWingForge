using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HawkWingForge.Models
{
    public partial class HawkWingForgeDevContext : DbContext
    {
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=tcp:hawkwingforge.database.windows.net,1433;Initial Catalog=HawkWingForgeDev;Persist Security Info=False;User ID=hwfDeveloperd;Password=-miLLer2forgE;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}

        public HawkWingForgeDevContext(DbContextOptions<HawkWingForgeDevContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Type).HasMaxLength(25);
            });
        }
    }
}