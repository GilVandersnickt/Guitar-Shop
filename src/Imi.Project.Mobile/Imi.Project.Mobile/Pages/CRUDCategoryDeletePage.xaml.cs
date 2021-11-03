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
    public partial class CRUDCategoryDeletePage : ContentPage
    {
        private readonly ICategoryService categoryService = new CategoryService();

        public List<Category> Categories { get => GetCategories(); }

        public CRUDCategoryDeletePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private List<Category> GetCategories()
        {
            return categoryService.Get().Result;
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (pkrCategory.SelectedItem != null)
            {
                var category = (Category)pkrCategory.SelectedItem;
                await categoryService.Delete(category.Id);
                await DisplayAlert("Confirm Delete", "Are you sure you want to delete this category?", "Yes", "No");
                await Navigation.PopAsync();
            }
        }
    }
}