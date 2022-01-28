using Imi.Project.Mobile.Domain.Services.Api;
using Imi.Project.Mobile.ViewModels;
using Xunit;

namespace Imi.Project.Mobile.Tests.ViewModels
{
    public class CRUDBrandAddViewModelTests
    {
        [Fact]
        public void ValidateCRUDBrandAddViewModel_WithValidInput_ReturnsTrue()
        {
            // Arrange
            var mockBrandsService = new ApiBrandsService();
            var mockViewModel = new CRUDBrandAddViewModel(mockBrandsService);
            var expectedResult = true;
            string brandName = "testBrand";
            // Act
            var result = mockViewModel.Validate(brandName);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDBrandAddViewModel_WithInvalidInput_ReturnsFalse()
        {
            // Arrange
            var mockBrandsService = new ApiBrandsService();
            var mockViewModel = new CRUDBrandAddViewModel(mockBrandsService);
            var expectedResult = false;
            string brandName = "";
            // Act
            var result = mockViewModel.Validate(brandName);
            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
