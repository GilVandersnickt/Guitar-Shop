using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
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
                    Brand newBrand = BrandToEdit;
                    newBrand.Name = BrandName;

                    if (BrandImageSource != null)
                        newBrand.Image = BrandImageSource.ToString();
                    else
                        newBrand.Image = "";

                    var confirmed = await CoreMethods.DisplayAlert("Confirm Edit", "Are you sure you want to edit this brand?", "Yes", "No");
                    if (confirmed)
                    {
                        await _brandService.Update(newBrand);
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
