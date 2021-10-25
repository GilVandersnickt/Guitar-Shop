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
                // Fender
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000002") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000005") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000011") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000013") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000014") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000023") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000035") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000036") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000040") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000041") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000043") },
                // Gibson
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000004") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000005") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006") },
                // Gretsch
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000034") },
                // Ibanez
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000002") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000022") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000032") },
                // Yamaha
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000004") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000016") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000017") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000044") },
                // Taylor
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000013") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000023") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042") },
                // Martin
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000007"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000007"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000045") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000007"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000046") },
                // Evh
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001") },     
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006") },     
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010") },     
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000011") },     
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000035") },     
                // Roland       
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000008") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000019") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000021") },
                // Marshall
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000011") },
                // Vox
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000029") },
                // Kemper
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000012"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010") },
                // Strymon
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000013"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000024") },
                // Elixir
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000014"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000038") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000014"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000039") },
                // Boss
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000009") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000025") },
                new BrandSubcategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"), SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000026") }
                );
        }
    }

}
