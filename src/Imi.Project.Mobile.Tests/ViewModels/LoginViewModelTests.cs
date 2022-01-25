using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Services.Api;
using Imi.Project.Mobile.ViewModels;
using Xunit;

namespace Imi.Project.Mobile.Tests
{
    public class LoginViewModelTests
    {
        [Fact]
        public void ValidateLoginViewModel_WithValidInput_ReturnsTrue()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new LoginViewModel(mockService);
            var expectedResult = true;
            string username = "testuser";
            string password = "testpassword";
            // Act
            var result = mockViewModel.Validate(username, password);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateLoginViewModel_WithInalidInput_ReturnsFalse()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new LoginViewModel(mockService);
            var expectedResult = false;
            string username = "testuser";
            string password = "";
            // Act
            var result = mockViewModel.Validate(username, password);
            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
