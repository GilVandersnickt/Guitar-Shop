using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using Imi.Project.Mobile.Domain.Services.Local;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Imi.Project.Mobile.Tests.Services
{
    public class ProductServiceTest
    {
        Product[] testProducts;
        public ProductServiceTest()
        {
            testProducts = TestData.TestProducts;
        }
        [Fact]
        public void Get_Returns_ProductById()
        {
            // Arrange
            var productService = new ProductService();
            var testProduct = testProducts.Last();

            var mockProductRepo = new Mock<IProductService>();
            mockProductRepo.Setup(repo => repo.Get(testProduct.Id))
                .ReturnsAsync(testProduct);

            // Act
            var product = productService.Get(testProduct.Id);
            // Assert
            Assert.NotNull(product);
            Assert.IsType<Product>(product.Result);
            Assert.Equal(testProduct.Id, product.Result.Id);
        }
        [Fact]
        public void Get_Returns_ProductsList()
        {
            // Arrange
            var productService = new ProductService();
            var products = new List<Product>();
            foreach (var product in testProducts)
            {
                products.Add(product);
            }
            var mockProductRepo = new Mock<IProductService>();
            mockProductRepo.Setup(repo => repo.Get())
                .ReturnsAsync(products);
            // Act
            var productsList = productService.Get();
            // Assert
            Assert.NotNull(productsList);
            Assert.IsType<List<Product>>(productsList.Result);
        }

        [Fact]
        public void Add_Returns_AddedProduct()
        {
            // Arrange
            var testId = Guid.NewGuid();
            var productService = new ProductService();
            var testProductRequest = new ProductRequest
            {
                Id = testId,
                Name = "TestProduct",
                Image = new Uri("https://i.postimg.cc/1X9YcxyL/Placeholder.jpg"),
                Price = "100",
                BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001")
            };
            var testProductResponse = new ProductResponse
            {
                Id = testId,
                Name = "TestProduct",
                Image = new Uri("https://i.postimg.cc/1X9YcxyL/Placeholder.jpg"),
                Price = 100,
                Brand = null,
                Category = null,
                Subcategory = null
            };

            var mockProductRepo = new Mock<IProductService>();
            mockProductRepo.Setup(repo => repo.Add(testProductRequest))
                .ReturnsAsync(testProductResponse);

            // Act
            var addedProduct = productService.Add(testProductRequest);
            // Assert
            Assert.NotNull(addedProduct);
            Assert.IsType<ProductResponse>(addedProduct.Result);
            Assert.Equal(testProductRequest.Name, addedProduct.Result.Name);
        }
        [Fact]
        public void Update_Returns_UpdatedProduct()
        {
            // Arrange
            var productService = new ProductService();
            var testProductRequest = new ProductRequest
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "TestProduct",
                Image = new Uri("https://i.postimg.cc/1X9YcxyL/Placeholder.jpg"),
                Price = "100",
                BrandId = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                CategoryId = Guid.Parse("00000000-0000-0000-0002-000000000001"),
                SubcategoryId = Guid.Parse("00000000-0000-0000-0003-000000000001")
            };
            var testProductResponse = new ProductResponse
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "TestProduct",
                Image = new Uri("https://i.postimg.cc/1X9YcxyL/Placeholder.jpg"),
                Price = 100,
                Brand = null,
                Category = null,
                Subcategory = null
            };

            var mockProductRepo = new Mock<IProductService>();
            mockProductRepo.Setup(repo => repo.Update(testProductRequest))
                .ReturnsAsync(testProductResponse);

            // Act
            var addedProduct = productService.Update(testProductRequest);
            // Assert
            Assert.NotNull(addedProduct);
            Assert.IsType<ProductResponse>(addedProduct.Result);
            Assert.Equal(testProductRequest.Name, addedProduct.Result.Name);
        }
        [Fact]
        public void Delete_Returns_DeletedProduct()
        {
            // Arrange
            var productService = new ProductService();
            var testProduct = testProducts.Last();
            var id = testProduct.Id;
            var mockProductRepo = new Mock<IProductService>();
            mockProductRepo.Setup(repo => repo.Delete(testProduct.Id))
                .ReturnsAsync(testProduct);

            // Act
            var deletedProduct = productService.Delete(testProduct.Id);
            // Assert
            Assert.NotNull(deletedProduct);
            Assert.Equal(id, deletedProduct.Result.Id);
        }

    }
}
