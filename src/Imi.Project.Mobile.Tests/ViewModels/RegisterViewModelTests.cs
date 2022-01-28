using Imi.Project.Mobile.Domain.Models.Api.Login;
using Imi.Project.Mobile.Domain.Services.Api;
using Imi.Project.Mobile.ViewModels;
using System;
using Xunit;

namespace Imi.Project.Mobile.Tests
{
    public class RegisterViewModelTests
    {
        [Fact]
        public void ValidateRegisterViewModel_WithValidInput_ReturnsEmptyString()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new RegisterViewModel(mockService);
            var request = new RegisterRequest()
            {
                UserName = "John",
                Password = "Test123?",
                PasswordConfirm = "Test123?",
                Address = "testadres",
                City = "teststad",
                BirthDate = DateTime.Now,
                EmailAddress = "test@hotmail.com",
                PostalCode = 8000
            };
            var expectedResult = string.Empty;
            // Act
            var result = mockViewModel.Validate(request);
            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ValidateRegisterViewModel_WithTooShortPassword_ReturnsErrorMessage()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new RegisterViewModel(mockService);
            var request = new RegisterRequest()
            {
                UserName = "John",
                Password = "Test",
                PasswordConfirm = "Test",
                Address = "testadres",
                City = "teststad",
                BirthDate = DateTime.Now,
                EmailAddress = "test@hotmail.com",
                PostalCode = 8000
            };
            var expectedResult = "Password length is too short";
            // Act
            var result = mockViewModel.Validate(request);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateRegisterViewModel_WithPasswordWithoutNumber_ReturnsErrorMessage()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new RegisterViewModel(mockService);
            var request = new RegisterRequest()
            {
                UserName = "John",
                Password = "TestPassword?",
                PasswordConfirm = "TestPassword?",
                Address = "testadres",
                City = "teststad",
                BirthDate = DateTime.Now,
                EmailAddress = "test@hotmail.com",
                PostalCode = 8000
            };
            var expectedResult = "Password must contain number";
            // Act
            var result = mockViewModel.Validate(request);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateRegisterViewModel_WithPasswordWithoutUpperCase_ReturnsErrorMessage()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new RegisterViewModel(mockService);
            var request = new RegisterRequest()
            {
                UserName = "John",
                Password = "test123?",
                PasswordConfirm = "test123?",
                Address = "testadres",
                City = "teststad",
                BirthDate = DateTime.Now,
                EmailAddress = "test@hotmail.com",
                PostalCode = 8000
            };
            var expectedResult = "Password must contain upper case letter";
            // Act
            var result = mockViewModel.Validate(request);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateRegisterViewModel_WithPasswordWithoutSymbol_ReturnsErrorMessage()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new RegisterViewModel(mockService);
            var request = new RegisterRequest()
            {
                UserName = "John",
                Password = "Test123",
                PasswordConfirm = "Test123",
                Address = "testadres",
                City = "teststad",
                BirthDate = DateTime.Now,
                EmailAddress = "test@hotmail.com",
                PostalCode = 8000
            };
            var expectedResult = "Password must contain symbol";
            // Act
            var result = mockViewModel.Validate(request);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateRegisterViewModel_WithUnmatchingPasswords_ReturnsErrorMessage()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new RegisterViewModel(mockService);
            var request = new RegisterRequest()
            {
                UserName = "John",
                Password = "Test123??",
                PasswordConfirm = "Test123?",
                Address = "testadres",
                City = "teststad",
                BirthDate = DateTime.Now,
                EmailAddress = "test@hotmail.com",
                PostalCode = 8000
            };
            var expectedResult = "Passwords must match";
            // Act
            var result = mockViewModel.Validate(request);
            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void ValidateRegisterViewModel_WithInvalidPostalCode_ReturnsErrorMessage()
        {
            // Arrange
            var mockService = new ApiUserService();
            var mockViewModel = new RegisterViewModel(mockService);
            var request = new RegisterRequest()
            {
                UserName = "John",
                Password = "Test123??",
                PasswordConfirm = "Test123?",
                Address = "testadres",
                City = "teststad",
                BirthDate = DateTime.Now,
                EmailAddress = "test@hotmail.com",
                PostalCode = 0
            };
            var expectedResult = "Postal code must be a valid code";
            // Act
            var result = mockViewModel.Validate(request);
            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
