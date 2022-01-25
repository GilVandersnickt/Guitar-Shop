using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Api;
using Imi.Project.Mobile.ViewModels;
using System;
using Xunit;

namespace Imi.Project.Mobile.Tests.ViewModels
{
    public class CRUDBrandUpdateViewModelTests
    {
        [Fact]
        public void ValidateCRUDBrandUpdateViewModel_WithValidInput_ReturnsTrue()
        {
            // Arrange
            var mockBrandsService = new ApiBrandsService();
            var mockViewModel = new CRUDBrandUpdateViewModel(mockBrandsService);
            var expectedResult = true;
            var testBrand = new Brand
            {
                Id = Guid.NewGuid(),
                Name = "TestBrand",
                Image = "https://TestBrand.PNG"
            };
            // Act
            var result = mockViewModel.Validate(testBrand);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateCRUDBrandUpdateViewModel_WithInvalidInput_ReturnsFalse()
        {
            // Arrange
            var mockBrandsService = new ApiBrandsService();
            var mockViewModel = new CRUDBrandUpdateViewModel(mockBrandsService);
            var expectedResult = false;
            Brand testBrand = null;
            // Act
            var result = mockViewModel.Validate(testBrand);
            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
