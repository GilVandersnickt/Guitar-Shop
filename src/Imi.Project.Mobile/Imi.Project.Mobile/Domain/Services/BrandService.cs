using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class BrandService : IBrandService
    {
        private static List<Brand> brands = new List<Brand>
        {
            #region Seeding
                
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
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    Name = "Ibanez",
                    Image = "Ibanez.PNG"
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    Name = "Yamaha",
                    Image = "Yamaha.PNG"
                },
                new Brand
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    Name = "Roland",
                    Image = "Roland.png"
                },
#endregion
        };

        public async Task<Brand> Add(Brand brand)
        {
            brands.Add(brand);
            return await Task.FromResult(brand);
        }

        public async Task<Brand> Delete(Guid id)
        {
            var oldBrandList = brands.FirstOrDefault(e => e.Id == id);
            brands.Remove(oldBrandList);
            return await Task.FromResult(oldBrandList);
        }

        public async Task<List<Brand>> Get()
        {
            return await Task.FromResult(brands);
        }

        public async Task<Brand> Get(Guid id)
        {
            var brand = brands.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(brand);
        }

        public async Task<Brand> Update(Brand brand)
        {
            var oldBucketList = brands.FirstOrDefault(e => e.Id == brand.Id);
            brands.Remove(oldBucketList);
            brands.Add(brand);
            return await Task.FromResult(brand);
        }
    }
}
