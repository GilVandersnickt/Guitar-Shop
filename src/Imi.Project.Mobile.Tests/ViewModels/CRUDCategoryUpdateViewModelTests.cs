using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Api;
using Imi.Project.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Imi.Project.Mobile.Tests.ViewModels
{
    public class CRUDCategoryUpdateViewModelTests
    {
        [Fact]
        public void ValidateCRUDCategoryUpdateViewModel_WithValidInput_ReturnsTrue()
        {
            // Arrange
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDCategoryUpdateViewModel(mockCategoryService);
            var expectedResult = true;
            var testCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "testCategory",
                Image = "https://TestCategory.PNG"
            };
            // Act
            var result = mockViewModel.Validate(testCategory);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDCategoryUpdateViewModel_WithInvalidInput_ReturnsFalse()
        {
            // Arrange
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDCategoryUpdateViewModel(mockCategoryService);
            var expectedResult = false;
            Category testCategory = null;
            // Act
            var result = mockViewModel.Validate(testCategory);
            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
