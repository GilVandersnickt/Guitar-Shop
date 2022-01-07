using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDBrandAddViewModel : FreshBasePageModel
    {
        private readonly IBrandService brandService;
        public CRUDBrandAddViewModel()
        {
            brandService = new BrandService();
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

        #endregion

        #region Commands
        public ICommand SaveBrand => new Command(
            async () =>
            {
                if (BrandName != null)
                {
                    Brand newBrand = new Brand();
                    newBrand.Id = Guid.NewGuid();
                    newBrand.Name = BrandName;

                    if (BrandImageSource != null)
                        newBrand.Image = BrandImageSource.ToString();
                    else
                        newBrand.Image = "";

                    await brandService.Add(newBrand);
                    await CoreMethods.PopModalNavigationService();
                }
            }
        );
        public ICommand TakePhoto => new Command(
            async () =>
            {
                var result = await MediaPicker.CapturePhotoAsync();
                if (result != null)
                {
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
                    var stream = await result.OpenReadAsync();
                    BrandImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        #endregion

    }
}
