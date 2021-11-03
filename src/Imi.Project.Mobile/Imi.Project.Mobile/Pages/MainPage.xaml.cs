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

        private void cvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}