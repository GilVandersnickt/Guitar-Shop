using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrandsPage : ContentPage
    {
        private readonly IBrandService brandService = new BrandService();
        public List<Brand> Brands { get => GetBrands(); }

        public BrandsPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Brand> GetBrands()
        {
            return brandService.Get().Result;
        }

        private async void cvBrands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var brand = e.CurrentSelection.FirstOrDefault() as Brand;
            if (brand == null)
                return;
            await Navigation.PushAsync(new ProductsPage(brand));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}