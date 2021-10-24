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

                // Electric guitar subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                    Name = "Stratocaster electric guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000002"),
                    Name = "Telecaster electric guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                    Name = "Single cut electric guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000004"),
                    Name = "Double cut electric guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000005"),
                    Name = "Other electric guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001")
                },

                // Amp subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000006"),
                    Name = "Tube combo amps",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000007"),
                    Name = "Solid state combo amps",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000008"),
                    Name = "Modeling combo amps",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000009"),
                    Name = "Loadboxes",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000010"),
                    Name = "Tops",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000011"),
                    Name = "Cabinets",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002")
                },

                // Bass guitar subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000012"),
                    Name = "Electric bass guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000013"),
                    Name = "Acoustic bass guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000014"),
                    Name = "5 string bass guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003")
                },

                // Classical guitar subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000015"),
                    Name = "1/4 classical guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000016"),
                    Name = "3/4 classical guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000017"),
                    Name = "4/4 classical guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000018"),
                    Name = "Other classical guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004")
                },

                // Cable subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000019"),
                    Name = "Guitar cables",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000020"),
                    Name = "Speaker cables",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000021"),
                    Name = "Patch cables",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005")
                },

                // Capodaster subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000022"),
                    Name = "Flat capodasters",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000006")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000023"),
                    Name = "Curved capodasters",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000006")
                },

                // Effect subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000024"),
                    Name = "Reverb / Delay / Echo effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000025"),
                    Name = "Tremolo / Vibrato / Rotary effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000026"),
                    Name = "Distortion effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000027"),
                    Name = "Overdrive effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000028"),
                    Name = "Compressor effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000029"),
                    Name = "Wah wah effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000030"),
                    Name = "Expression effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000031"),
                    Name = "Other effects",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007")
                }, 

                // Miscellaneous instrument subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000032"),
                    Name = "Mandolines",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000008")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000033"),
                    Name = "Banjos",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000008")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000034"),
                    Name = "Other miscellaneous instruments",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000008")
                },

                // Pickup subcategories          
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000035"),
                    Name = "Humbucker pickups",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000009")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000036"),
                    Name = "Single coil pickups",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000009")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000037"),
                    Name = "Other pickups",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000009")
                },

                // String subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000038"),
                    Name = "Electric strings",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000039"),
                    Name = "Acoustic strings",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000040"),
                    Name = "Nylon strings",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000041"),
                    Name = "Other strings",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010")
                },

                // Acoustic guitar subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000042"),
                    Name = "Dreadnought guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000043"),
                    Name = "Semi acoustic guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011")
                }, 
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000044"),
                    Name = "Other acoustic guitars",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011")
                },

                // Ukulele subcategories
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000045"),
                    Name = "Concert ukuleles",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000012")
                },
                new Subcategory
                {
                    Id = Guid.Parse("00000000-0000-0000-0003-000000000046"),
                    Name = "Other ukuleles",
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000012")
                }
            );
        }
    }
}
