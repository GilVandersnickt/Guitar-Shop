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
                    Name = "Electric guitars",
                    Image = new Uri("https://i.postimg.cc/8CHNz2QB/Electric-Guitars.png")
                }, 
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    Name = "Amps",
                    Image= new Uri("https://i.postimg.cc/3NWK6nqj/Amps.png")
                }, 
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    Name = "Bass guitars",
                    Image= new Uri("https://i.postimg.cc/HLhHMQnV/Bass-Guitars.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000004"),
                    Name = "Classical guitars",
                    Image= new Uri("https://i.postimg.cc/prDt34ZF/Classical-Guitars.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000005"),
                    Name = "Cables", 
                    Image= new Uri("https://i.postimg.cc/Kz3bDR3Q/Cables.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000006"),
                    Name = "Capodasters",
                    Image= new Uri("https://i.postimg.cc/vTRsqbWy/Capodasters.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000007"),
                    Name = "Effects",
                    Image= new Uri("https://i.postimg.cc/mgZG6dFP/Effects.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000008"),
                    Name = "Miscellaneous instruments",
                    Image= new Uri("https://i.postimg.cc/7P7DCJkZ/Miscellaneous-Instruments.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000009"),
                    Name = "Pickups",
                    Image= new Uri("https://i.postimg.cc/jd4bcVCV/Pickups.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000010"),
                    Name = "Strings",
                    Image= new Uri("https://i.postimg.cc/zXrNTDzS/Strings.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000011"),
                    Name = "Acoustic guitars",
                    Image= new Uri("https://i.postimg.cc/rwhL6SSQ/Western-Guitars.png")
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000012"),
                    Name = "Ukuleles",
                    Image= new Uri("https://i.postimg.cc/66d3kmTc/Ukuleles.png")
                }
            );
        }
    }
}
