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
    public partial class CRUDBrandUpdatePage : ContentPage
    {
        private readonly IBrandService brandService = new BrandService();
        public List<Brand> Brands { get => GetBrands(); }


        public CRUDBrandUpdatePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Brand> GetBrands()
        {
            return brandService.Get().Result;
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
            Brand selectedBrand = (Brand)pkrBrand.SelectedItem;
            Brand brand = brandService.Get(selectedBrand.Id).Result;

            brand.Id = pkrBrand.Id;
            brand.Name = txtBrandName.Text;
            if (imgPhoto.Source != null)
                brand.Image = imgPhoto.Source.ToString();
            else
                brand.Image = "";

            await brandService.Update(brand);
            await Navigation.PopAsync();
        }

        private void pkrBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brand selectedBrand = (Brand)pkrBrand.SelectedItem;
            imgPhoto.Source = selectedBrand.Image;
            txtBrandName.Text = selectedBrand.Name;
        }
    }
}