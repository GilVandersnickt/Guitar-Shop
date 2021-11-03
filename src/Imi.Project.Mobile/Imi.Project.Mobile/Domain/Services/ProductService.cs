using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
            #region Seeding
            
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Fender american ultra stratocaster ultraburst",
                    Price = 1000M,
                    Image = "fenderamericanultrastratocasterhssmnultraburstGIT0050645000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Fender eric clapton stratocaster almond green",
                    Price = 1000M,
                    Image = "fenderericclaptonstratocastermnalmondgreenmasterbuilttoddkrausecz552554GIT0057454000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    Name = "Gibson les paul studio smokehouse burst",
                    Price = 1000M,
                    Image = "gibsonlespaulstudiosmokehouseburstGIT0049498000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                    Name = "Gibson les paul tribute satin tobacco sunburst",
                    Price = 1000M,
                    Image = "gibsonlespaultributesatintobaccosunburstGIT0049503000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },

                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                    Name = "Gretsch g5230t electromatic jet ft single cut bigsby airline silver",
                    Price = 1000M,
                    Image = "gretschg5230telectromaticjetftsinglecutbigsbyairlinesilverGIT0047791000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                    Name = "Gretsch g6128t players edition jet ft bigsby roundup orange",
                    Price = 1000M,
                    Image = "gretschg6128tplayerseditionjetftbigsbyrounduporangeGIT0051980000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },

                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                    Name = "Fender 64 custom deluxe reverb",
                    Price = 1000M,
                    Image = "fender64customdeluxereverbGIT0042604000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                    Name = "Yamaha thr30ii wireless",
                    Price = 1000M,
                    Image = "yamahathr30iiwirelessGIT0051343000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000008"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                    Name = "Fender american original 60s precision bass rw surf green",
                    Price = 1000M,
                    Image = "fenderamericanoriginal60sprecisionbassrwsurfgreenBAS0010757000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000031"),
                    Name = "Ibanez standard sr600e ast antique brown stained burst",
                    Price = 1000M,
                    Image = "ibanezstandardsr600eastantiquebrownstainedburstBAS0011488000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000036"),
                    Name = "Yamaha cs 40 nt 3/4 natural",
                    Price = 1000M,
                    Image = "yamahacs40nt34naturalGIT0000644000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000016"),
                },
                // 4/4 classical
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000037"),
                    Name = "Yamaha c 40 m",
                    Price = 1000M,
                    Image = "yamahac40mmatGIT0019253000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000017"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000038"),
                    Name = "Roland ric g10a gold series 6m",
                    Price = 1000M,
                    Image = "rolandricg10agoldseriesACC0007014000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000019"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000039"),
                    Name = "Roland ric bpc patchcable 0,15m",
                    Price = 1000M,
                    Image = "rolandricbpcpatchkabel015mACC0007020000.png",
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000021"),
                },

#endregion
        };

        public async Task<Product> Add(Product product)
        {
            products.Add(product);
            return await Task.FromResult(product);
        }

        public async Task<Product> Delete(Guid id)
        {
            var oldProductList = products.FirstOrDefault(e => e.Id == id);
            products.Remove(oldProductList);
            return await Task.FromResult(oldProductList);
        }

        public async Task<List<Product>> Get()
        {
            return await Task.FromResult(products);
        }
        public async Task<List<Product>> GetProductsByBrand(Brand brand)
        {
            var productsByBrand = products.Where(p => p.BrandId == brand.Id).ToList();
            return await Task.FromResult(productsByBrand);
        }

        public async Task<List<Product>> GetProductsByCategory(Category category)
        {
            var productsByBrand = products.Where(p => p.CategoryId == category.Id).ToList();
            return await Task.FromResult(productsByBrand);
        }

        public async Task<Product> Get(Guid id)
        {
            var product = products.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(product);
        }

        public async Task<Product> Update(Product product)
        {
            var oldBucketList = products.FirstOrDefault(e => e.Id == product.Id);
            products.Remove(oldBucketList);
            products.Add(product);
            return await Task.FromResult(product);
        }

    }
}
