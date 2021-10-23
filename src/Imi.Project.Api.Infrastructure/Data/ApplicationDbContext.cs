using Imi.Project.Api.Entities;
using Imi.Project.Api.Infrastructure.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }
        public DbSet<BrandSubcategory> BrandSubcategories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            // Many to many brands categories
            modelBuilder.Entity<BrandCategory>()
                .ToTable("BrandCategory")
                .HasKey(bc => new { bc.BrandId, bc.CategoryId });
            modelBuilder.Entity<BrandCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BrandCategories)
                .HasForeignKey(bc => bc.CategoryId);
            modelBuilder.Entity<BrandCategory>()
                .HasOne(bc => bc.Brand)
                .WithMany(b => b.BrandCategories)
                .HasForeignKey(bc => bc.BrandId);

            // Many to many brands subcategories
            modelBuilder.Entity<BrandSubcategory>()
                .ToTable("BrandSubcategory")
                .HasKey(bs => new { bs.BrandId, bs.SubcategoryId });
            modelBuilder.Entity<BrandSubcategory>()
                .HasOne(bs => bs.Subcategory)
                .WithMany(bs => bs.BrandSubcategories)
                .HasForeignKey(bs => bs.SubcategoryId);
            modelBuilder.Entity<BrandSubcategory>()
                .HasOne(bc => bc.Brand)
                .WithMany(b => b.BrandSubcategories)
                .HasForeignKey(bc => bc.BrandId);

            ProductSeeder.Seed(modelBuilder);
            BrandSeeder.Seed(modelBuilder);
            CategorySeeder.Seed(modelBuilder);
            SubcategorySeeder.Seed(modelBuilder);
            BrandCategorySeeder.Seed(modelBuilder);
            BrandSubcategorySeeder.Seed(modelBuilder);
        }
    }
}
