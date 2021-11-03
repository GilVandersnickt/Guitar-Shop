using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCartPage : ContentPage
    {
        public ShoppingCartPage()
        {
            InitializeComponent();
        }

        private async void btnProceed_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransactionPage());
        }

        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}