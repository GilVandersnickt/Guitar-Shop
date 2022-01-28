using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDCategoryDeleteViewModel : FreshBasePageModel
    {
        private readonly ICategoryService _categoryService;

        public CRUDCategoryDeleteViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #region Properties
        private Category categoryToDelete;
        public Category CategoryToDelete
        {
            get { return categoryToDelete; }
            set
            {
                categoryToDelete = value;
                RaisePropertyChanged(nameof(CategoryToDelete));
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
        #endregion
        #region Commands
        public ICommand DeleteCategory => new Command(
            async () =>
            {
                if (CategoryToDelete.Id != null)
                {
                    var confirmed = await CoreMethods.DisplayAlert("Confirm Delete", "Are you sure you want to delete this category?", "Yes", "No");
                    if (confirmed)
                    {
                        await _categoryService.Delete(CategoryToDelete.Id);
                        await CoreMethods.PopModalNavigationService();
                    }
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
            var categories = await _categoryService.Get();
            Categories = new ObservableCollection<Category>(categories);
        }
    }
}
