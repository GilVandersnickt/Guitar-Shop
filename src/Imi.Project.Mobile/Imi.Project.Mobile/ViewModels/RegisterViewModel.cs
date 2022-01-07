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
        public ICommand OpenMainPageCommand => new Command<User>(
            async (User user) =>
            {
                await CoreMethods.PushPageModel<MainViewModel>(user, false, true);
            }
        );


    }
}
