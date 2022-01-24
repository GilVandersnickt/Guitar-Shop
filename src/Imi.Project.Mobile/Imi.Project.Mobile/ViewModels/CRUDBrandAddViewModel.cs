using FreshMvvm;
using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDBrandAddViewModel : FreshBasePageModel
    {
        private readonly IBrandService _brandService;
        public CRUDBrandAddViewModel(IBrandService brandService)
        {
            _brandService = brandService;
        }
        #region Properties
        private Brand brandToAdd;
        public Brand BrandToAdd
        {
            get { return brandToAdd; }
            set
            {
                brandToAdd = value;
                RaisePropertyChanged(nameof(BrandToAdd));
            }
        }
        private string brandName;
        public string BrandName
        {
            get { return brandName; }
            set
            {
                brandName = value;
                RaisePropertyChanged(nameof(BrandName));
            }
        }
        private ImageSource brandImageSource;
        public ImageSource BrandImageSource
        {
            get { return brandImageSource; }
            set
            {
                brandImageSource = value;
                RaisePropertyChanged(nameof(BrandImageSource));
            }
        }
        private FileResult brandImage;
        public FileResult BrandImage
        {
            get { return brandImage; }
            set
            {
                brandImage = value;
                RaisePropertyChanged(nameof(BrandImage));
            }
        }
        #endregion

        #region Commands
        public ICommand SaveBrand => new Command(
            async () =>
            {
                if (BrandName != null)
                {
                    var confirmed = await CoreMethods.DisplayAlert("Confirm Add", "Are you sure you want to add this brand?", "Yes", "No");
                    if (confirmed)
                    {
                        Brand newBrand = new Brand();
                        newBrand.Id = Guid.NewGuid();
                        newBrand.Name = BrandName;
                        newBrand.Image = ApiSettings.ImagePlaceHolder;

                        var brand = await _brandService.Add(newBrand);
                        if (brand != null && BrandImage != null)
                            await _brandService.AddImage(brand.Id, await BrandImage.OpenReadAsync());

                        await CoreMethods.PopModalNavigationService();
                    }
                }
            }
        );
        public ICommand TakePhoto => new Command(
            async () =>
            {
                var result = await MediaPicker.CapturePhotoAsync();
                if (result != null)
                {
                    BrandImage = result;
                    var stream = await result.OpenReadAsync();
                    BrandImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        public ICommand UploadPhoto => new Command(
            async () =>
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please choose an image"
                });
                if (result != null)
                {
                    BrandImage = result;
                    var stream = await result.OpenReadAsync();
                    BrandImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        #endregion

    }
}
