using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Imi.Project.Mobile.Domain.Services.Local;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Imi.Project.Mobile.Tests.Services
{
    public class BrandServiceTests
    {
        Brand[] testBrands;
        public BrandServiceTests()
        {
            testBrands = TestData.TestBrands;
        }
        [Fact]
        public void Get_Returns_BrandById()
        {
            // Arrange
            var brandService = new BrandService();
            var testBrand = testBrands.Last();

            var mockBrandRepo = new Mock<IBrandService>();
            mockBrandRepo.Setup(repo => repo.Get(testBrand.Id))
                .ReturnsAsync(testBrand);

            // Act
            var addedBrand = brandService.Get(testBrand.Id);
            // Assert
            Assert.NotNull(addedBrand);
            Assert.IsType<Brand>(addedBrand.Result);
            Assert.Equal(testBrand.Id, addedBrand.Result.Id);
        }
        [Fact]
        public void Get_Returns_BrandsList()
        {
            // Arrange
            var brandService = new BrandService();
            var brands = new List<Brand>();
            foreach (var brand in testBrands)
            {
                brands.Add(brand);
            }
            var mockBrandRepo = new Mock<IBrandService>();
            mockBrandRepo.Setup(repo => repo.Get())
                .ReturnsAsync(brands);
            // Act
            var brandsList = brandService.Get();
            // Assert
            Assert.NotNull(brandsList);
            Assert.IsType<List<Brand>>(brandsList.Result);
        }

        [Fact]
        public void Add_Returns_AddedBrand()
        {
            // Arrange
            var brandService = new BrandService();
            var testBrand = new Brand { Id = Guid.NewGuid(), Name = "TestBrand", Image = "TestImage.png" };

            var mockBrandRepo = new Mock<IBrandService>();
            mockBrandRepo.Setup(repo => repo.Add(testBrand))
                .ReturnsAsync(testBrand);

            // Act
            var addedBrand = brandService.Add(testBrand);
            // Assert
            Assert.NotNull(addedBrand);
            Assert.IsType<Brand>(addedBrand.Result);
            Assert.Equal(testBrand, addedBrand.Result);
        }
        [Fact]
        public void Update_Returns_UpdatedBrand()
        {
            // Arrange
            var testBrand = new Brand { Id = Guid.NewGuid(), Name = "TestBrand", Image = "TestImage.png" };

            var mockBrandRepo = new Mock<IBrandService>();
            mockBrandRepo.Setup(repo => repo.Update(testBrand))
                .ReturnsAsync(testBrand);

            var brandService = new BrandService();
            // Act
            var addedBrand = brandService.Update(testBrand);
            // Assert
            Assert.NotNull(addedBrand);
            Assert.IsType<Brand>(addedBrand.Result);
            Assert.Equal(testBrand, addedBrand.Result);
        }
        [Fact]
        public void Delete_Returns_DeletedBrand()
        {
            // Arrange
            var brandService = new BrandService();
            var testBrand = testBrands.Last();

            var mockBrandRepo = new Mock<IBrandService>();
            mockBrandRepo.Setup(repo => repo.Delete(testBrand.Id))
                .ReturnsAsync(testBrand);

            // Act
            var deletedBrand = brandService.Delete(testBrand.Id);
            // Assert
            Assert.NotNull(deletedBrand);
            Assert.IsType<Brand>(deletedBrand.Result);
            Assert.Equal(testBrand.Id, deletedBrand.Result.Id);
        }

    }
}
