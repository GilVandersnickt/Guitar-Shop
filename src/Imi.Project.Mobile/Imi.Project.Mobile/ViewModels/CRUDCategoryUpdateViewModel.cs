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
    public class CRUDCategoryUpdateViewModel : FreshBasePageModel
    {
        private readonly ICategoryService _categoryService;

        public CRUDCategoryUpdateViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
        private FileResult categoryImage;
        public FileResult CategoryImage
        {
            get { return categoryImage; }
            set
            {
                categoryImage = value;
                RaisePropertyChanged(nameof(CategoryImage));
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
                if (Validate(CategoryToEdit))
                {
                    var confirmed = await CoreMethods.DisplayAlert("Confirm Edit", "Are you sure you want to edit this category?", "Yes", "No");
                    if (confirmed)
                    {
                        Category newCategory = CategoryToEdit;
                        newCategory.Name = CategoryName;

                        var category = await _categoryService.Update(newCategory);
                        if (category != null && CategoryImage != null)
                            await _categoryService.AddImage(CategoryToEdit.Id, await CategoryImage.OpenReadAsync());

                        await CoreMethods.PopModalNavigationService();
                    }
                }
                else
                    await CoreMethods.DisplayAlert("Invalid input", "Select a category to edit", "Ok");
            }
        );
        public ICommand TakePhoto => new Command(
            async () =>
            {
                var result = await MediaPicker.CapturePhotoAsync();
                if (result != null)
                {
                    CategoryImage = result;
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
                    CategoryImage = result;
                    var stream = await result.OpenReadAsync();
                    CategoryImageSource = ImageSource.FromStream(() => stream);
                }
            }
        );
        #endregion
        #region Validate
        public bool Validate(Category category)
        {
            if (category == null)
                return false;
            else
                return true;
        }
        #endregion

        public async override void Init(object initData)
        {
            base.Init(initData);

            await RefreshCategoriesList();
        }
        private async Task RefreshCategoriesList()
        {
            var categories = await _categoryService.Get();
            Categories = new ObservableCollection<Category>(categories);

            if (CategoryToEdit == null)
            {
                CategoryToEdit = new Category();
            }
        }

    }
}
