using Imi.Project.Mobile.Domain.Services.Api;
using Imi.Project.Mobile.ViewModels;
using Xunit;

namespace Imi.Project.Mobile.Tests.ViewModels
{
    public class CRUDProductAddViewModelTests
    {
        [Fact]
        public void ValidateCRUDProductAddViewModel_WithValidInput_ReturnsTrue()
        {
            // Arrange
            var mockProductService = new ApiProductService();
            var mockBrandsService = new ApiBrandsService();
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDProductAddViewModel(mockProductService, mockBrandsService, mockCategoryService);
            var expectedResult = true;
            string productName = "testuser";
            string productPrice = "123";
            // Act
            var result = mockViewModel.Validate(productName, productPrice);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDProductAddViewModel_WithInvalidPrice_ReturnsFalse()
        {
            // Arrange
            var mockProductService = new ApiProductService();
            var mockBrandsService = new ApiBrandsService();
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDProductAddViewModel(mockProductService, mockBrandsService, mockCategoryService);
            var expectedResult = false;
            string productName = "testuser";
            string productPrice = "qsd";
            // Act
            var result = mockViewModel.Validate(productName, productPrice);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDProductAddViewModel_WithInvalidProductName_ReturnsFalse()
        {
            // Arrange
            var mockProductService = new ApiProductService();
            var mockBrandsService = new ApiBrandsService();
            var mockCategoryService = new ApiCategoryService();
            var mockViewModel = new CRUDProductAddViewModel(mockProductService, mockBrandsService, mockCategoryService);
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
