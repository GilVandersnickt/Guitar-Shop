using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api.Login;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RegisterViewModel : FreshBasePageModel
    {
        private readonly IUserService _userService;
        public RegisterViewModel(IUserService userService)
        {
            _userService = userService;
        }
        #region Properties
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged(nameof(UserName));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        private string passwordConfirm;
        public string PasswordConfirm
        {
            get { return passwordConfirm; }
            set
            {
                passwordConfirm = value;
                RaisePropertyChanged(nameof(PasswordConfirm));
            }
        }
        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                RaisePropertyChanged(nameof(EmailAddress));
            }
        }
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                RaisePropertyChanged(nameof(BirthDate));
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }
        private string postalCode;
        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                RaisePropertyChanged(nameof(PostalCode));
            }
        }
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged(nameof(City));
            }
        }
        private DateTime maxDate;
        public DateTime MaxDate
        {
            get { return maxDate; }
            set
            {
                maxDate = value;
                RaisePropertyChanged(nameof(MaxDate));
            }
        }
        #endregion
        #region Commands
        public ICommand Register => new Command<User>(
            async (User user) =>
            {
                int postalcode;

                RegisterRequest registerRequest = new RegisterRequest();
                if (!int.TryParse(PostalCode, out postalcode))
                    await CoreMethods.DisplayAlert("Invalid input", "Enter valid postal code", "Ok");
                else
                {
                    registerRequest.PostalCode = postalcode;
                    registerRequest.UserName = UserName;
                    registerRequest.Password = Password;
                    registerRequest.PasswordConfirm = PasswordConfirm;
                    registerRequest.EmailAddress = EmailAddress;
                    registerRequest.Address = Address;
                    registerRequest.BirthDate = BirthDate;
                    registerRequest.City = City;

                    string error = Validate(registerRequest);

                    if (error.Equals(string.Empty))
                    {
                        var response = await _userService.Register(registerRequest);
                        if (response)
                        {
                            await CoreMethods.DisplayAlert("Successfull registration", "You can now login!", "Enter the shop");
                            await CoreMethods.PushPageModel<MainViewModel>(true);
                        }
                        else
                        {
                            var proceed = await CoreMethods.DisplayAlert("Invalid registration", $"Continue without registering?", "Yes", "No");
                            if (proceed)
                                await CoreMethods.PushPageModel<MainViewModel>(true);
                        }
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Invalid input", $"{error}", "Ok");
                    }
                }
            }
        );
        #endregion
        #region Validate
        public string Validate(RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.PasswordConfirm) || string.IsNullOrEmpty(request.EmailAddress) || string.IsNullOrEmpty(request.Address) || string.IsNullOrEmpty(request.City))
                return "Enter all input fields";
            else if (request.PostalCode == 0)
                return "Postal code must be a valid code";
            else if (request.Password != request.PasswordConfirm)
                return "Passwords must match";
            else if (request.Password.Length < 7)
                return "Password length is too short";
            else if (!request.Password.Any(x => char.IsPunctuation(x)))
                return "Password must contain symbol";
            else if (!request.Password.Any(x => char.IsUpper(x)))
                return "Password must contain upper case letter";
            else if (!request.Password.Any(x => char.IsNumber(x)))
                return "Password must contain number";
            else
                return string.Empty;
        }
        #endregion
        public override void Init(object initData)
        {
            base.Init(initData);
            MaxDate = DateTime.Now;
            BirthDate = DateTime.Now;
        }
    }
}
