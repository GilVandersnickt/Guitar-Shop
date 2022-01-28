using Imi.Project.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class BrandSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(            
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    Name = "Fender",
                    Image = new Uri("https://i.postimg.cc/vBQJL50W/Fender.png")
                    
                }, 
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    Name = "Gibson",
                    Image = new Uri("https://i.postimg.cc/NfyW4skP/Gibson.png")
                    
                }, 
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    Name = "Gretsch",
                    Image = new Uri("https://i.postimg.cc/1tJLW4db/Gretsch.png")
                    
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    Name = "Ibanez",
                    Image = new Uri("https://i.postimg.cc/8ccxxNQc/Ibanez.png")
                    
                }, 
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    Name = "Yamaha",
                    Image = new Uri("https://i.postimg.cc/L5J0NDLZ/Yamaha.png")                   
                }, 
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000006"),
                    Name = "Taylor",
                    Image = new Uri("https://i.postimg.cc/cH9bR2gS/Taylor.png")                   
                }, 
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000007"),
                    Name = "Martin",
                    Image = new Uri("https://i.postimg.cc/SK43kWFw/Martin.png")                   
                }, 
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000008"),
                    Name = "Evh",
                    Image = new Uri("https://i.postimg.cc/DzKNc1xx/EVH.png")                   
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    Name = "Roland",
                    Image = new Uri("https://i.postimg.cc/g28QCg5V/Roland.png")                   
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000010"),
                    Name = "Marshall",
                    Image = new Uri("https://i.postimg.cc/CMr3kBkq/Marshall.png")                   
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000011"),
                    Name = "Vox",
                    Image = new Uri("https://i.postimg.cc/rmfYc3MH/Vox.png")                   
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000012"),
                    Name = "Kemper",
                    Image = new Uri("https://i.postimg.cc/W46HYtKT/Kemper.png")                   
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000013"),
                    Name = "Strymon",
                    Image = new Uri("https://i.postimg.cc/LX90c2Kf/Strymon.png")                   
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000014"),
                    Name = "Elixir",
                    Image = new Uri("https://i.postimg.cc/d0mMy5js/Elixir.png")                   
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000015"),
                    Name = "Boss",
                    Image = new Uri("https://i.postimg.cc/mrGfkvMp/Boss.png")                   
                }                         
            );
        }
    }
}
