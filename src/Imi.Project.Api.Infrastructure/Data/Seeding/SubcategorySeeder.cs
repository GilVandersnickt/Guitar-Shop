using Imi.Project.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class SubcategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                    Name = "Electric guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000002"),
                    Name = "Tube amps",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                }
            );
        }
    }
}
