using FreshMvvm;
using Imi.Project.Mobile.Constants;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDBrandUpdateViewModel : FreshBasePageModel
    {
        private readonly IBrandService _brandService;

        public CRUDBrandUpdateViewModel(IBrandService brandService)
        {
            _brandService = brandService;
        }
        #region Properties
        private Brand brandToEdit;
        public Brand BrandToEdit
        {
            get { return brandToEdit; }
            set
            {
                brandToEdit = value;
                RaisePropertyChanged(nameof(BrandToEdit));
            }
        }
        private ObservableCollection<Brand> brands;
        public ObservableCollection<Brand> Brands
        {
            get { return brands; }
            set
            {
                brands = value;
                RaisePropertyChanged(nameof(Brands));
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
        public ICommand LoadBrand => new Command(
            () =>
            {
                if (BrandToEdit != null)
                {
                    BrandImageSource = BrandToEdit.Image;
                    BrandName = BrandToEdit.Name;
                }
            }
        );
        public ICommand SaveBrand => new Command(
            async () =>
            {
                if (BrandToEdit != null)
                {
                    var confirmed = await CoreMethods.DisplayAlert("Confirm Edit", "Are you sure you want to edit this brand?", "Yes", "No");
                    if (confirmed)
                    {
                        Brand newBrand = BrandToEdit;
                        newBrand.Name = BrandName;

                        var brand = await _brandService.Update(newBrand);
                        if (brand != null && BrandImage != null)
                            await _brandService.AddImage(BrandToEdit.Id, await BrandImage.OpenReadAsync());

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
        public async override void Init(object initData)
        {
            base.Init(initData);

            await RefreshBrandList();
        }
        private async Task RefreshBrandList()
        {
            var brands = await _brandService.Get();
            Brands = new ObservableCollection<Brand>(brands);

            if (BrandToEdit == null)
            {
                BrandToEdit = new Brand();
            }
        }
    }
}
