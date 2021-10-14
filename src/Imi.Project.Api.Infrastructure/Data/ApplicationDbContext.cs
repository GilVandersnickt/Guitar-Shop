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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                        BrandId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        SubcategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Marshall JVM",
                        BrandId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        SubcategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    },
            }
            );
        }
    }
}
