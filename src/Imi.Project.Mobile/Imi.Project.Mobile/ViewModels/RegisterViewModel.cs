using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RegisterViewModel : FreshBasePageModel
    {
        public RegisterViewModel()
        {

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
        public ICommand Register => new Command<User>(
            async (User user) =>
            {
                await CoreMethods.PushPageModel<MainViewModel>(user, false, true);
            }
        );
        #endregion

    }
}
