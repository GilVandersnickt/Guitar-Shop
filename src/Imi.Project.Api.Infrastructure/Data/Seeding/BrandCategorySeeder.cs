using Imi.Project.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class BrandCategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandCategory>().HasData(
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") }
                );
        }
    }
}
