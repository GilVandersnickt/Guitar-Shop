using Imi.Project.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    Name = "Guitars",
                }, new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    Name = "Amps",
                }
            );
        }
    }
}
