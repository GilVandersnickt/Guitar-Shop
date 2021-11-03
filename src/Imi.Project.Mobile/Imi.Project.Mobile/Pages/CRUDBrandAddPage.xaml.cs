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
    public partial class CRUDBrandAddPage : ContentPage
    {
        private readonly IBrandService brandService = new BrandService();

        public List<Brand> Brands { get => GetBrands(); }
        public string BrandDescription { get; set; }


        public CRUDBrandAddPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private List<Brand> GetBrands()
        {
            return brandService.Get().Result;
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            Brand newBrand = new Brand();
            newBrand.Id = Guid.NewGuid();
            newBrand.Name = txtBrandName.Text;
            if (imgPhoto.Source != null)
                newBrand.Image = imgPhoto.Source.ToString();
            else
                newBrand.Image = "";
            await brandService.Add(newBrand);

            await Navigation.PopAsync();
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
    }
}