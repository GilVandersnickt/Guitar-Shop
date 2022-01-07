using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDCategoryUpdateViewModel : FreshBasePageModel
    {
        private readonly ICategoryService categoryService;

        public CRUDCategoryUpdateViewModel()
        {
            categoryService = new CategoryService();
        }
        #region Properties
        private Category categoryToEdit;
        public Category CategoryToEdit
        {
            get { return categoryToEdit; }
            set
            {
                categoryToEdit = value;
                RaisePropertyChanged(nameof(CategoryToEdit));
            }
        }
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                RaisePropertyChanged(nameof(Categories));
            }
        }
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                RaisePropertyChanged(nameof(CategoryName));
            }
        }
        private ImageSource categoryImageSource;
        public ImageSource CategoryImageSource
        {
            get { return categoryImageSource; }
            set
            {
                categoryImageSource = value;
                RaisePropertyChanged(nameof(CategoryImageSource));
            }
        }
        #endregion

        #region Commands
        public ICommand LoadCategory => new Command(
            () =>
            {
                if (CategoryToEdit != null)
                {
                    CategoryImageSource = CategoryToEdit.Image;
                    CategoryName = CategoryToEdit.Name;
                }
            }
        );
        public ICommand SaveCategory => new Command(
            async () =>
            {
                if (CategoryToEdit != null)
                {
                    Category newCategory = CategoryToEdit;
                    newCategory.Name = CategoryName;

                    if (CategoryImageSource != null)
                        newCategory.Image = CategoryImageSource.ToString();
                    else
                        newCategory.Image = "";

                    var confirmed = await CoreMethods.DisplayAlert("Confirm Edit", "Are you sure you want to edit this category?", "Yes", "No");
                    if (confirmed)
                    {
                        await categoryService.Update(newCategory);
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
                    CategoryImageSource = ImageSource.FromStream(() => stream);
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
                    CategoryImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);

            await RefreshCategoriesList();
        }
        private async Task RefreshCategoriesList()
        {
            var categories = await categoryService.Get();
            Categories = new ObservableCollection<Category>(categories);

            if (CategoryToEdit == null)
            {
                CategoryToEdit = new Category();
            }
        }

    }
}
