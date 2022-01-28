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
    public class CategoryServiceTests
    {
        Category[] testCategories;
        public CategoryServiceTests()
        {
            testCategories = TestData.TestCategories;
        }
        [Fact]
        public void Get_Returns_CategoryById()
        {
            // Arrange
            var categoryService = new CategoryService();
            var testCategory = testCategories.Last();

            var mockCategoryRepo = new Mock<ICategoryService>();
            mockCategoryRepo.Setup(repo => repo.Get(testCategory.Id))
                .ReturnsAsync(testCategory);

            // Act
            var addedCategory = categoryService.Get(testCategory.Id);
            // Assert
            Assert.NotNull(addedCategory);
            Assert.Equal(testCategory.Id, addedCategory.Result.Id);
        }
        [Fact]
        public void Get_Returns_CategoriesList()
        {
            // Arrange
            var categoryService = new CategoryService();
            var categories = new List<Category>();
            foreach (var category in testCategories)
            {
                categories.Add(category);
            }
            var mockCategoryRepo = new Mock<ICategoryService>();
            mockCategoryRepo.Setup(repo => repo.Get())
                .ReturnsAsync(categories);
            // Act
            var categoriesList = categoryService.Get();
            // Assert
            Assert.NotNull(categoriesList);
            Assert.IsType<List<Category>>(categoriesList.Result);
        }

        [Fact]
        public void Add_Returns_AddedCategory()
        {
            // Arrange
            var categoryService = new CategoryService();
            var testCategory = new Category { Id = Guid.NewGuid(), Name = "testCategory", Image = "TestImage.png" };

            var mockCategoryRepo = new Mock<ICategoryService>();
            mockCategoryRepo.Setup(repo => repo.Add(testCategory))
                .ReturnsAsync(testCategory);

            // Act
            var addedBrand = categoryService.Add(testCategory);
            // Assert
            Assert.NotNull(addedBrand);
            Assert.Equal(testCategory, addedBrand.Result);
        }
        [Fact]
        public void Update_Returns_UpdatedCategory()
        {
            // Arrange
            var categoryService = new CategoryService();
            var testCategory = new Category { Id = Guid.NewGuid(), Name = "testCategory", Image = "TestImage.png" };
            var mockCategoryRepo = new Mock<ICategoryService>();

            mockCategoryRepo.Setup(repo => repo.Update(testCategory))
                .ReturnsAsync(testCategory);

            // Act
            var addedCategory = categoryService.Update(testCategory);
            // Assert
            Assert.NotNull(addedCategory);
            Assert.Equal(testCategory, addedCategory.Result);
        }
        [Fact]
        public void Delete_Returns_DeletedCategory()
        {
            // Arrange
            var categoryService = new CategoryService();
            var testCategory = testCategories.First();

            var mockCategoryRepo = new Mock<ICategoryService>();
            mockCategoryRepo.Setup(repo => repo.Delete(testCategory.Id))
                .ReturnsAsync(testCategory);

            // Act
            var deletedCategory = categoryService.Delete(testCategory.Id);
            // Assert
            Assert.NotNull(deletedCategory);
            Assert.Equal(testCategory.Id, deletedCategory.Result.Id);
        }
    }
}
