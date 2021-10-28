using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Imi.Project.Mobile
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            var loginPage = new LoginPage();
            Navigation.PushAsync(loginPage, true);
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            var registerPage = new RegisterPage();
            Navigation.PushAsync(registerPage, true);
        }
    }
}
