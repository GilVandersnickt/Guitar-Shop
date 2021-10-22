using Imi.Project.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class ProductSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Fender Stratocaster",
                    Price = 1000M,
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Marshall JVM",
                    Price = 1000M,
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000002"),
                }
            );
        }
    }
}
