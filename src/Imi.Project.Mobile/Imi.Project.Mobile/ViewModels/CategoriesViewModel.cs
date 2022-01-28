using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CategoriesViewModel : FreshBasePageModel
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #region Properties
        private Category selectedFilter;
        public Category SelectedFilter
        {
            get { return selectedFilter; }
            set
            {
                selectedFilter = value;
                RaisePropertyChanged(nameof(SelectedFilter));
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
        #endregion
        #region Commands
        public ICommand OpenCategoryProductsPageCommand => new Command<Category>(
           async (Category category) =>
           {
               if (category != null)
                   await CoreMethods.PushPageModel<ProductsViewModel>(category, false, true);
           }
        );
        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);
            Categories = new ObservableCollection<Category>(await _categoryService.Get());
        }

    }
}
