using Imi.Project.Blazor.Models.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public class BrandsService : ICRUDService<BrandListItem, BrandItem>
    {
        static List<BrandItem> brands = new List<BrandItem>
        {
            #region Seeding
                
                new BrandItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    Name = "Fender",
                    Image = "Fender.PNG"
                },
                new BrandItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    Name = "Gibson",
                    Image = "Gibson.PNG"
                },
                new BrandItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    Name = "Gretsch",
                    Image = "Gretsch.PNG"
                },
                new BrandItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    Name = "Ibanez",
                    Image = "Ibanez.PNG"
                },
                new BrandItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    Name = "Yamaha",
                    Image = "Yamaha.PNG"
                },
                new BrandItem
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    Name = "Roland",
                    Image = "Roland.png"
                },
#endregion
        };
        public Task<BrandListItem[]> GetList()
        {
            return Task.FromResult(
                brands.Select(x => new BrandListItem()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Image = x.Image
                }).ToArray()
            );
        }
        public Task<InputSelectItem[]> GetSelectList()
        {
            return Task.FromResult(
                brands.Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArray()
            );
        }
        public Task<BrandItem> GetNew()
        {
            return Task.FromResult(new BrandItem());
        }
        public Task<BrandItem> Get(Guid id)
        {
            return Task.FromResult(brands.SingleOrDefault(x => x.Id == id));
        }

        public Task Create(BrandItem item)
        {
            item.Id = Guid.NewGuid();
            brands.Add(item);
            return Task.CompletedTask;
        }

        public Task Update(BrandItem item)
        {
            var brand = brands.SingleOrDefault(x => x.Id == item.Id);
            if (brand == null) throw new ArgumentException("Brand not found!");
            brand.Name = item.Name;
            brand.Image = item.Image;
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            var brand = brands.SingleOrDefault(x => x.Id == id);
            if (brand == null) throw new ArgumentException("Brand not found!");
            brands.Remove(brand);
            return Task.CompletedTask;
        }

    }
}
