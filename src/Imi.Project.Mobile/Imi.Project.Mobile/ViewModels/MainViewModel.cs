using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;

        public MainViewModel()
        {
            categoryService = new CategoryService();
            brandService = new BrandService();
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


        #endregion
        #region Commands
        public ICommand OpenCategoriesPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModel<CategoriesViewModel>(true);
           }
        );
        public ICommand OpenCategoryProductsPageCommand => new Command<Category>(
           async (Category category) =>
           {
               await CoreMethods.PushPageModel<ProductsViewModel>(category, false, true);
           }
        );

        public ICommand OpenBrandsPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModel<BrandsViewModel>(true);
           }
        );
        public ICommand OpenBrandProductsPageCommand => new Command<Brand>(
           async (Brand brand) =>
           {
               await CoreMethods.PushPageModel<ProductsViewModel>(brand, false, true);
           }
        );

        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);

            await LoadMainPage();
        }

        private async Task LoadMainPage()
        {
            Categories = new ObservableCollection<Category>(await categoryService.Get());
            Brands = new ObservableCollection<Brand>(await brandService.Get());
        }


    }
}
