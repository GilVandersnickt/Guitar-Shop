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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void btnProducts_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CRUDProductPage());
        }

        private async void btnBrands_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CRUDBrandPage());
        }

        private async void btnCategories_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CRUDCategoryPage());
        }
    }
}