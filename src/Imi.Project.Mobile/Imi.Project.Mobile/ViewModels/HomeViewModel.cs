using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class HomeViewModel : FreshBasePageModel
    {
        public HomeViewModel()
        {

        }
        #region Commands
        public ICommand OpenLoginPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModel<LoginViewModel>(true);
           }
        );
        public ICommand OpenRegisterPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModel<RegisterViewModel>(true);
           }
        );
        public ICommand OpenAdminPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModel<AdminViewModel>(true);
           }
        );
        #endregion
    }
}
