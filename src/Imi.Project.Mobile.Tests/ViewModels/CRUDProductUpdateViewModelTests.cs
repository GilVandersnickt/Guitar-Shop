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
    public class CRUDProductUpdateViewModelTests
    {
        [Fact]
        public void ValidateCRUDProductUpdateViewModel_WithValidInput_ReturnsTrue()
        {
            // Arrange
            var mockProductService = new ApiProductService();
            var mockBrandsService = new ApiBrandsService();
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDProductUpdateViewModel(mockProductService, mockBrandsService, mockCategoryService);
            var expectedResult = true;
            string productName = "testuser";
            string productPrice = "123";
            // Act
            var result = mockViewModel.Validate(productName, productPrice);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDProductUpdateViewModel_WithInvalidPrice_ReturnsFalse()
        {
            // Arrange
            var mockProductService = new ApiProductService();
            var mockBrandsService = new ApiBrandsService();
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDProductUpdateViewModel(mockProductService, mockBrandsService, mockCategoryService);
            var expectedResult = false;
            string productName = "testuser";
            string productPrice = "qsd";
            // Act
            var result = mockViewModel.Validate(productName, productPrice);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDProductUpdateViewModel_WithInvalidProductName_ReturnsFalse()
        {
            // Arrange
            var mockProductService = new ApiProductService();
            var mockBrandsService = new ApiBrandsService();
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDProductUpdateViewModel(mockProductService, mockBrandsService, mockCategoryService);
            var expectedResult = false;
            string productName = "";
            string productPrice = "123";
            // Act
            var result = mockViewModel.Validate(productName, productPrice);
            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
