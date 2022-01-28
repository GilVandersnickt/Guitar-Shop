using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api.Default;
using System;

namespace Imi.Project.Mobile.Tests.Services
{
    class TestData
    {
        public static Brand[] TestBrands => new[] {
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    Name = "Fender",
                    Image = "Fender.PNG"
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    Name = "Gibson",
                    Image = "Gibson.PNG"
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    Name = "Gretsch",
                    Image = "Gretsch.PNG"
                },
        };
        public static Category[] TestCategories => new[] {
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    Name = "Electric guitars",
                    Image = "Electric_Guitars.PNG"
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    Name = "Amps",
                    Image= "Amps.PNG"
                },
                new Category
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    Name = "Bass guitars",
                    Image= "Bass_Guitars.PNG"
                },
        }; 
        public static Product[] TestProducts => new[] {
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Fender american ultra stratocaster ultraburst",
                    Price = 1000M,
                    Image = "fenderamericanultrastratocasterhssmnultraburstGIT0050645000.png",
                    Brand = new DefaultModelWithImage
                        {
                            Id = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                            Name = "Fender",
                            Image = "Fender.PNG"
                        },
                    Category = new DefaultModelWithImage
                        {
                            Id = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                            Name = "Electric guitars",
                            Image = "Electric_Guitars.PNG"
                        },
                    Subcategory = new DefaultModel{}
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Fender eric clapton stratocaster almond green",
                    Price = 1000M,
                    Image = "fenderericclaptonstratocastermnalmondgreenmasterbuilttoddkrausecz552554GIT0057454000.png",
                    Brand = new DefaultModelWithImage
                        {
                            Id = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                            Name = "Fender",
                            Image = "Fender.PNG"
                        },
                    Category = new DefaultModelWithImage
                        {
                            Id = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                            Name = "Electric guitars",
                            Image = "Electric_Guitars.PNG"
                        },
                    Subcategory = new DefaultModel{}
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    Name = "Gibson les paul studio smokehouse burst",
                    Price = 1000M,
                    Image = "gibsonlespaulstudiosmokehouseburstGIT0049498000.png",
                    Brand = new DefaultModelWithImage
                        {
                            Id = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                            Name = "Gibson",
                            Image = "Gibson.PNG"
                        },
                    Category = new DefaultModelWithImage
                        {
                            Id = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                            Name = "Electric guitars",
                            Image = "Electric_Guitars.PNG"
                        },
                    Subcategory = new DefaultModel{}
                },
        };
    }
}
