using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class BrandsViewModel : FreshBasePageModel
    {
        private readonly IBrandService _brandService;

        public BrandsViewModel(IBrandService brandService)
        {
            _brandService = brandService;
        }
        #region Properties
        private Brand selectedFilter;
        public Brand SelectedFilter
        {
            get { return selectedFilter; }
            set
            {
                selectedFilter = value;
                RaisePropertyChanged(nameof(SelectedFilter));
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
        public ICommand OpenBrandProductsPageCommand => new Command<Brand>(
           async (Brand brand) =>
           {
               if (brand != null)
                   await CoreMethods.PushPageModel<ProductsViewModel>(brand, false, true);
           }
        );
        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);
            Brands = new ObservableCollection<Brand>(await _brandService.Get());
        }

    }
}
