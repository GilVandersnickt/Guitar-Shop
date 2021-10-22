using Imi.Project.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class BrandSubcategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandSubcategory>().HasData(
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000002") }
                );
        }
    }

}
