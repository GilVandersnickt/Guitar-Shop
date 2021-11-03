using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
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
    public partial class CRUDBrandDeletePage : ContentPage
    {
        private readonly IBrandService brandService = new BrandService();

        public List<Brand> Brands { get => GetBrands(); }

        public CRUDBrandDeletePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private List<Brand> GetBrands()
        {
            return brandService.Get().Result;
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if(pkrBrand.SelectedItem != null)
            {
                var brand = (Brand)pkrBrand.SelectedItem;
                await brandService.Delete(brand.Id);
                await DisplayAlert("Confirm Delete", "Are you sure you want to delete this brand?", "Yes", "No");
                await Navigation.PopAsync();
            }
        }
    }
}