using Imi.Project.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class ProductSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            #region Electric guitars
                // Stratocaster
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Fender american ultra stratocaster ultraburst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/59wJPgVL/fender-american-ultra-stratocaster-hss-mn-ultraburst-1-GIT0050645-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Fender eric clapton stratocaster almond green",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/0NMR7dn6/fender-eric-clapton-stratocaster-mn-almond-green-masterbuilt-todd-krause-cz552554-1-GIT0057454-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Evh striped series frankie",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/JzFS7H8R/evh-striped-series-frankie-1-GIT0052080-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Name = "Ibanez martin miller mm1 tab az signature transparent aqua blue",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/pXqg711h/ibanez-martin-miller-mm1-tab-az-signature-transparent-aqua-blue-1-GIT0044682-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001"),
                },
                // Telecaster
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Name = "Fender american ultra telecaster rw ultrabust",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/W14P1PJw/fender-american-ultra-telecaster-rw-ultraburst-1-GIT0050649-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000002"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    Name = "Ibanez azs2200 bk prestige black",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/T2q8jPVc/ibanez-azs2200-bk-prestige-black-1-GIT0055975-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000002"),
                },
                // Single cut
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                    Name = "Gibson les paul studio smokehouse burst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/KzB6HGdx/gibson-les-paul-studio-smokehouse-burst-1-GIT0049498-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                    Name = "Gibson les paul tribute satin tobacco sunburst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/Kjb6SX2L/gibson-les-paul-tribute-satin-tobacco-sunburst-1-GIT0049503-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                    Name = "Gretsch g5230t electromatic jet ft single cut bigsby airline silver",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/Qxm3DMVM/gretsch-g5230t-electromatic-jet-ft-single-cut-bigsby-airline-silver-1-GIT0047791-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                    Name = "gretsch g6128t players edition jet ft bigsby roundup orange",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/VLYxKc4P/gretsch-g6128t-players-edition-jet-ft-bigsby-roundup-orange-1-GIT0051980-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000003"),
                },
                // Double cut
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                    Name = "Gibson sg standard 61 vintage cherry",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/x8PW9sfZ/gibson-sg-standard-61-vintage-cherry-1-GIT0049508-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000004"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                    Name = "Yamaha revstar rs620 seg snake eye green",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/W1zQP6Q9/yamaha-revstar-rs620-seg-snake-eye-green-1-GIT0045092-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000004"),
                },
                // Other electric guitars
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
                    Name = "Gibson 70s flying v classic white",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/W1fcDfGL/gibson-70s-flying-v-classic-white-1-GIT0051791-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000002"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000005"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
                    Name = "Fender limited edition 59 jazzmaster dlx classic desert sand",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/rpB6j0Zf/fender-limited-edition-59-250k-jazzmaster-dlx-closet-classic-desert-sand-cz550958-1-GIT0056948-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000005"),
                },
            #endregion
            #region Amps
                // Tube combo amps
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
                    Name = "Fender 64 custom deluxe reverb",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/gkMNWwF4/fender-64-custom-deluxe-reverb-1-GIT0042604-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
                    Name = "Evh 5150iii 2x12 50w 6l6 combo ivory",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/QdHSxXjD/evh-5150iii-2x12-50w-6l6-combo-ivory-1-GIT0045576-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000017"),
                    Name = "Marshall jvm 410 c combo",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/9f9pZJ4N/marshall-jvm-410-c-combo-1-GIT0010132-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000018"),
                    Name = "Vox ac15c1x",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/26fxwhhj/vox-ac15c1x-1-GIT0037041-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000115"),
                    Name = "Vox ac30hw2 combo",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/5y4ScJsZ/vox-ac30hw2-combo-1-GIT0020205-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000006"),
                },
                // Solid state amps
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000116"),
                    Name = "Fender tone master deluxe reverb",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/hGKj1GhW/fender-tone-master-deluxe-reverb-1-GIT0050563-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000117"),
                    Name = "Boss katana artist mkii",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/SxFjjdhK/boss-katana-artist-mkii-1-GIT0052539-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000118"),
                    Name = "Roland jc 120b jazz chorus combo",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/PqKq3k8L/roland-jc-120b-jazz-chorus-combo-1-GIT0000966-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000119"),
                    Name = "Marshall mg50fx mg gold",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/15Nf9TbT/marshall-mg50fx-mg-gold-guitar-combo-amplifier-1-GIT0043010-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000019"),
                    Name = "Vox vx50 gtv",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/Z58nNNbx/vox-vx50-gtv-1-GIT0048389-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000007"),
                },
                // Modeling amps
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                    Name = "Yamaha thr30ii wireless",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/wMzggfJK/yamaha-thr30ii-wireless-1-GIT0051343-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000008"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000021"),
                    Name = "Roland blauwscube artist combo",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/4NJs00sV/roland-blauwscube-artist-combo-1-GIT0032556-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000008"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000022"),
                    Name = "Fender tone master super reverb",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/MKdqJYp4/fender-tone-master-super-reverb-1-GIT0056974-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000008"),
                },
                // Loadboxes
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000023"),
                    Name = "Boss waza tube amp expander",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/K8pGB5XL/boss-waza-tube-amp-expander-1-GIT0047642-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000015"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000009"),
                },
                // Tops
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000024"),
                    Name = "Kemper prof ler power head remote",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/VvF16qBJ/kemper-prof-ler-power-head-remote-1-GIT0034433-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000012"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000025"),
                    Name = "Fender bassbreaker 45 head",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/XvZV8y3P/fender-bassbreaker-45-head-1-GIT0037389-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000026"),
                    Name = "Evh 5150iii 50w el34 head",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/nzBn8bXY/evh-5150iii-50w-el34-head-1-GIT0043477-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000027"),
                    Name = "Marshall jtm45 head",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/nL6nwchh/marshall-jtm45-head-2245-1-GIT0009522-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000010"),
                },
                // Cabinets
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000028"),
                    Name = "Marshall 1960 ahw cabinet",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/9QQXDnkC/marshall-1960-ahw-cabinet-1-GIT0006190-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000010"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000011"),
                },
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000029"),
                    Name = "Evh 5150 iconic series 4x12 cabinet",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/XNKnQWSn/evh-5150-iconic-series-4x12-cabinet-black-1-GIT0057179-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000011"),
                },
            #endregion
            #region Bass guitars
                // Electric
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                    Name = "Fender american original 60s precision bass rw surf green",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/ZqfwTCdJ/fender-american-original-60s-precision-bass-rw-surf-green-1-BAS0010757-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000031"),
                    Name = "Ibanez standard sr600e ast antique brown stained burst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/tCPvhqLz/ibanez-standard-sr600e-ast-antique-brown-stained-burst-1-BAS0011488-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000032"),
                    Name = "Yamaha bbp34 vintage sunburst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/HkgZ3Gm1/yamaha-bbp34-vintage-sunburst-1-BAS0009170-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000012"),
                },
                // Acoustic
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000033"),
                    Name = "Fender fa 450ce bass 3 tone sunburst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/C1XJqX7t/fender-fa-450ce-bass-3-tone-sunburst-1-BAS0010213-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000013"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000034"),
                    Name = "Taylor gs mini e koa bass",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/s2fndp1n/taylor-gs-mini-e-koa-bass-1-BAS0010808-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000013"),
                },
                // 5 string
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000035"),
                    Name = "Fender american professional ii azz bass v mn roasted pine",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/C1zmdSGk/fender-american-professional-ii-jazz-bass-v-mn-roasted-pine-1-BAS0011257-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000003"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000014"),
                },
            #endregion
            #region Classical guitars
                // 1/4 classical
                // 3/4 classical
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000036"),
                    Name = "Yamaha cs 40 nt 3/4 natural",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/Jh1PjbLN/yamaha-cs-40-nt-3-4-natural-1-GIT0000644-000.png"),
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
                    Image = new Uri("https://i.postimg.cc/sgPTBTtf/yamaha-c-40-m-mat-1-GIT0019253-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000004"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000017"),
                },
                // Other classical
            #endregion
            #region Cables
                // Guitar cables
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000038"),
                    Name = "Roland ric g10a gold series 6m",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/c4n9Wxhn/roland-ric-g10a-gold-series-1-ACC0007014-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000019"),
                },
                // Speaker cables
                // Patch cables
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000039"),
                    Name = "Roland ric bpc patchcable 0,15m",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/rmsjPMzz/roland-ric-bpc-patchkabel-0-15-m-1-ACC0007020-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000009"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000005"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000021"),
                },
            #endregion
            #region Capodasters
                // Flat
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000040"),
                    Name = "Ibanez igcz10 capo flat",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/Px7yG98y/ibanez-igcz10-capodaster-1-GIT0046854-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000006"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000022"),
                },
                // Curved
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000041"),
                    Name = "Fender smart capo standard curved",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/NFr4QD6c/fender-fscst-smart-capo-standaard-curved-1-GIT0019827-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000006"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000023"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000042"),
                    Name = "Taylor capo 6 string nickel curved",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/zf0p7Vz9/taylor-capo-6-string-bright-nickel-1-GIT0049116-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000006"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000023"),
                },
            #endregion
            #region Effects
                // Reverb delay
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000043"),
                    Name = "Strymon big sky multi reverb",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/fyGJhjK1/strymon-big-sky-multi-reverb-1-GIT0029813-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000013"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000024"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000044"),
                    Name = "Strymon el capistan tape delay",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/g0sX6hz6/strymon-el-capistan-dtape-delay-1-GIT0022459-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000013"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000024"),
                },
                // Tremolo vibrato
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000045"),
                    Name = "Boxx tr-2 tremolo",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/tJZYfmhh/boss-tr-2-tremolo-1-GIT0000578-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000025"),
                },
                // Distortion
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000046"),
                    Name = "Boss ds-2 turbo distortion",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/MTrn98j6/boss-ds-2-turbo-distortion-1-GIT0000572-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000026"),
                },
                // Overdrive
                // Compressor
                // Wah wah
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000047"),
                    Name = "Vox v847a wah",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/NM0y80FC/vox-v847a-wah-1-GIT0011824-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000011"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000007"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000029"),
                },
                // Expression
                // Other
            #endregion
            #region Miscellaneous instruments
                // Mandolines
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000048"),
                    Name = "Ibanez m510e bs manoline brown sunburst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/1tsvS2M1/ibanez-m510e-bs-mandoline-brown-sunburst-1-GIT0012278-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000008"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000032"),
                },
                // Banjos
                // Other
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000049"),
                    Name = "Gretsch g5700 lap steel tobacco sunburst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/63cYpc12/gretsch-g5700-lap-steel-tobacco-sunburst-1-GIT0003805-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000003"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000008"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000034"),
                },
            #endregion
            #region Pickups
                // Humbucker
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000050"),
                    Name = "Evh frankensteen humbucker",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/8CcwyMyL/evh-frankensteen-humbucker-1-GIT0020048-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000008"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000009"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000035"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000051"),
                    Name = "Fender double tap bridge humbucker",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/DZb6hF3Z/fender-double-tap-bridge-humbucker-1-GIT0054676-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000009"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000035"),
                },
                // Single coil
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000052"),
                    Name = "Fender custom shop nocaster tele set singlecoils",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/6QPcFqSg/fender-custom-shop-nocaster-tele-2er-set-singlecooils-1-GIT0001347-001.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000009"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000036"),
                },
                // Other
            #endregion
            #region Strings
                // Electric
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000053"),
                    Name = "Elixir electric optiweb",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/4ycXpKkg/elixir-19002-optiweb-1-GIT0040893-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000014"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000038"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000054"),
                    Name = "Elixir electric nanoweb",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/tChXTVNd/elixir-e-git-snaren-09-42-12002-nanoweb-1-ACC0000532-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000014"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000038"),
                },
                // Acoustic
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000055"),
                    Name = "Elixir acoustic nanoweb phosphor bronze",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/ZYvbGQ9M/elixir-a-git-snaren-10-47-16002-nanoweb-phosphor-bronze-1-GIT0008353-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000014"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000039"),
                },
                // Nylon
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000056"),
                    Name = "Fender nylon classical",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/8P8pNbMP/fender-nylon-git-snaren-100-clear-tie-end-1-GIT0018438-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000040"),
                },
                // Other
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000153"),
                    Name = "Fender concert ukulele",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/0yP9J2VT/fender-california-coast-concert-ukulele-strings-1-GIT0044910-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000010"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000041"),
                },
            #endregion
            #region Acoustic guitars
                // Dreadnought
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000154"),
                    Name = "Fender ct redondo special mah",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/SRH7tvv9/fender-ct-redondo-special-mah-1-GIT0053479-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000155"),
                    Name = "Martin hd 28 ambertone",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/2jtw61S5/martin-guitars-hd-28-ambertone-1-GIT0045786-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000007"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000156"),
                    Name = "Taylor 717e wild honey burst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/XJHg9JKQ/taylor-builder-s-edition-717e-wild-honey-burst-1-GIT0048533-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000006"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000057"),
                    Name = "Yamaha fg3",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/XqrkLbQ3/yamaha-fg3-1-GIT0049915-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000042"),
                },
                // Semi-acoustic
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000058"),
                    Name = "Fender am acoustasonic transparant sonic blue",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/7hXMqLhg/fender-am-acoustasonic-stratocaster-transparent-sonic-blue-1-GIT0052562-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000043"),
                },
                // Other acoustic 
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000059"),
                    Name = "Yamaha silent guitar crimson red burst",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/Gtbx0DLL/yamaha-silent-guitar-slg-200-s-crimson-red-burst-steel-strings-1-GIT0052653-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000005"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000011"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000044"),
                },
            #endregion
            #region Ukuleles
                // Concert
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000060"),
                    Name = "Fender fullerton tele uke butterscotch blonde",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/J4ZH30MK/fender-fullerton-tele-uke-butterscotch-blonde-1-GIT0052267-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000012"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000045"),
                }, new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000061"),
                    Name = "Ibanez ukc10 ukulele",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/FHxfq6fL/ibanez-ukc10-ukulele-1-GIT0023444-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000004"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000012"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000045"),
                },
                // Other               
                new Product
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000062"),
                    Name = "Martin c1k concert uke solid hawaiian koa",
                    Price = 1000M,
                    Image = new Uri("https://i.postimg.cc/9Q2RL2f2/martin-guitars-c1k-concert-uke-solid-hawaiian-koa-1-GIT0030099-000.png"),
                    BrandId = Guid.Parse("00000000-0000-0000-0001-000000000007"),
                    CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000012"),
                    SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000046"),
                }
                #endregion
            );
        }
    }
}
