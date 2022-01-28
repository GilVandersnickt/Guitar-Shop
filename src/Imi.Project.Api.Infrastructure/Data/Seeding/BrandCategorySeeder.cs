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
                // Fender
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000006") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000008") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000009") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000012") },
                // Gibson
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011") },
                // Gretsch
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001") },
                // Ibanez
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001") },
                // Yamaha
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000006") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011") },
                // Taylor
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011") },

                // Martin
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000007"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011") },

                // Evh
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },

                // Roland
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005") },

                // Marshall
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007") },

                // Vox
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },

                // Kemper
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000012"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },

                // Strymon
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000013"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007") },

                // Elixir
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000014"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010") },

                // Boss
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002") },
                new BrandCategory { BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"), CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007") }
                );
        }
    }
}
