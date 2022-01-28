using FreshMvvm;
using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Models.Api.Login;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        private readonly IUserService _userService;
        private readonly IDeviceFlashlightService _deviceFlashlightService;

        public LoginViewModel(IUserService userService, IDeviceFlashlightService deviceFlashlightService)
        {
            _userService = userService;
            _deviceFlashlightService = deviceFlashlightService;
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
        #endregion
        #region Commands
        public ICommand Login => new Command(
            async () =>
            {
                if (!Validate(UserName, Password))
                    await CoreMethods.DisplayAlert("Invalid input", "Enter username and password", "Ok");
                else
                {
                    LoginRequest request = new LoginRequest { UserName = this.UserName, Password = this.Password };
                    var response = await _userService.Login(request);
                    if (response && (request.UserName.Equals(ApiSettings.AdminUsername) || request.UserName.Equals(ApiSettings.SuperAdminUsername)))
                        await CoreMethods.PushPageModel<AdminViewModel>(true);
                    else if (response)
                        await CoreMethods.PushPageModel<MainViewModel>(true);
                    else
                    {
                        var proceed = await CoreMethods.DisplayAlert("Invalid login", "Continue without logging in?", "Yes", "No");
                        if (proceed)
                            await CoreMethods.PushPageModel<MainViewModel>(true);
                    }
                }
            }
        );
        public ICommand ForgotPassword => new Command(
            async () =>
            {
                await CoreMethods.DisplayAlert("Forgot your password?", "Too bad ...", "Thanks!");
            }
        );
        public ICommand TurnOnFlashlight => new Command(
            () =>
            {
                _deviceFlashlightService.TurnOn();
            }
        );
        public ICommand TurnOffFlashlight => new Command(
            () =>
            {
                _deviceFlashlightService.TurnOff();
            }
        );

        #endregion
        #region Validate
        public bool Validate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;
            else
                return true;
        }
        #endregion

        public override void Init(object initData)
        {
            base.Init(initData);

            UserName = ApiSettings.AdminUsername;
            Password = ApiSettings.AdminPassword;
        }

    }
}
