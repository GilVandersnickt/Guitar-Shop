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
    public partial class MainPage : ContentPage
    {
        private readonly ICategoryService categoryService = new CategoryService();
        private readonly IBrandService brandService = new BrandService();
        public List<Category> Categories { get => GetCategories(); }
        public List<Brand> Brands { get => GetBrands(); }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }


        private List<Category> GetCategories()
        {
            return categoryService.Get().Result;           
        }
        private List<Brand> GetBrands()
        {
            return brandService.Get().Result;
        }

        private void Categories_Clicked(object sender, EventArgs e)
        {
            var categoriesPage = new CategoriesPage();
            Navigation.PushAsync(categoriesPage, true);
        }
        private void Brands_Clicked(object sender, EventArgs e)
        {
            var brandsPage = new BrandsPage();
            Navigation.PushAsync(brandsPage, true);
        }

        private async void cvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Category;
            if (category == null)
                return;
            await Navigation.PushAsync(new ProductsPage(category));
            ((CollectionView)sender).SelectedItem = null;
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