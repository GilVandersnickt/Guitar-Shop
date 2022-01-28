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
    public class CRUDCategoryAddViewModelTests
    {
        [Fact]
        public void ValidateCRUDcategoryAddViewModel_WithValidInput_ReturnsTrue()
        {
            // Arrange
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDCategoryAddViewModel(mockCategoryService);
            var expectedResult = true;
            string categoryName = "testCategory";
            // Act
            var result = mockViewModel.Validate(categoryName);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDCategoryAddViewModel_WithInvalidInput_ReturnsFalse()
        {
            // Arrange
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDCategoryAddViewModel(mockCategoryService);
            var expectedResult = false;
            string categoryName = "";
            // Act
            var result = mockViewModel.Validate(categoryName);
            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
