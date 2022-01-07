using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        public LoginViewModel()
        {

        }
        #region Commands
        public ICommand OpenMainPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<MainViewModel>(true);
            }
        );
        #endregion

    }
}
