using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDCategoryUpdatePage : ContentPage
    {
        private readonly ICategoryService categoryService = new CategoryService();

        public List<Category> Categories { get => GetCategories(); }


        public CRUDCategoryUpdatePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Category> GetCategories()
        {
            return categoryService.Get().Result;
        }
        private async void btnTakePhoto_Clicked(object sender, EventArgs e)
        {
            var selectedBrand = ((Button)sender).CommandParameter as Brand;
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                imgPhoto.Source = ImageSource.FromStream(() => stream);
            }

        }
        private async void btnUploadPhoto_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please choose an image"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                imgPhoto.Source = ImageSource.FromStream(() => stream);
            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if(pkrCategory.SelectedItem != null)
            {
                Category selectedCategory = (Category)pkrCategory.SelectedItem;
                Category category = categoryService.Get(selectedCategory.Id).Result;

                selectedCategory.Id = pkrCategory.Id;
                selectedCategory.Name = txtCategoryName.Text;

                if (imgPhoto.Source != null)
                    selectedCategory.Image = imgPhoto.Source.ToString();
                else
                    selectedCategory.Image = "";

                await categoryService.Update(category);
                await Navigation.PopAsync();
            }
        }

        private void pkrCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category selectedCategory = (Category)pkrCategory.SelectedItem;
            imgPhoto.Source = selectedCategory.Image;
            txtCategoryName.Text = selectedCategory.Name;
        }
    }
}