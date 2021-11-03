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
    public partial class CategoriesPage : ContentPage
    {
        private readonly ICategoryService categoryService = new CategoryService();
        public List<Category> Categories { get => GetCategories(); }

        public CategoriesPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Category category = e.SelectedItem as Category;

            Navigation.PushAsync(new ProductsPage(category));
        }
        private List<Category> GetCategories()
        {
            return categoryService.Get().Result;
        }

        private async void cvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Category;
            if (category == null)
                return;
            await Navigation.PushAsync(new ProductsPage(category));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}