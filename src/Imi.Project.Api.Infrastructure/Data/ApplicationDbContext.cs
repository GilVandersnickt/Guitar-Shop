using Imi.Project.Api.Entities;
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
                .HasKey(bc => new { bc.BrandId, bc.SubcategoryId });
            modelBuilder.Entity<BrandSubcategory>()
                .HasOne(bc => bc.Subcategory)
                .WithMany(c => c.BrandSubcategories)
                .HasForeignKey(bc => bc.SubcategoryId);
            modelBuilder.Entity<BrandSubcategory>()
                .HasOne(bc => bc.Brand)
                .WithMany(b => b.BrandSubcategories)
                .HasForeignKey(bc => bc.BrandId);


            // Brands
            modelBuilder.Entity<Brand>().HasData(
                new[]
                {
                    new Brand
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Fender",
                    }, new Brand
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Marshall",
                    },
                }
                );

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new[]
                {
                    new Category
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Guitars",
                    }, new Category
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Amps",
                    },
                }
                );

            // Subcategories
            modelBuilder.Entity<Subcategory>().HasData(
                new[]
                {
                    new Subcategory
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Electric guitars",
                    }, new Subcategory
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Tube amps",
                    },
                }
                );

            //Products
            modelBuilder.Entity<Product>().HasData(
            new[]
            {
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Fender Stratocaster",
                        Price = 1000M,
                        BrandId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        SubcategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Marshall JVM",
                        Price = 1000M,
                        BrandId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        SubcategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    },
            }
            );
        }
    }
}
