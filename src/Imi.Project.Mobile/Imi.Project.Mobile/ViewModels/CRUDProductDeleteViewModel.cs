using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CRUDProductDeleteViewModel : FreshBasePageModel
    {
        private readonly IProductService _productService;

        public CRUDProductDeleteViewModel(IProductService productService)
        {
            _productService = productService;
        }
        #region Properties
        private Product productToDelete;
        public Product ProductToDelete
        {
            get { return productToDelete; }
            set
            {
                productToDelete = value;
                RaisePropertyChanged(nameof(ProductToDelete));
            }
        }
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                RaisePropertyChanged(nameof(Products));
            }
        }
        #endregion
        #region Commands
        public ICommand DeleteProduct => new Command(
            async () =>
            {
                if (ProductToDelete.Id != null)
                {
                    var confirmed = await CoreMethods.DisplayAlert("Confirm Delete", "Are you sure you want to delete this product?", "Yes", "No");
                    if (confirmed)
                    {
                        await _productService.Delete(ProductToDelete.Id);
                        await CoreMethods.PopModalNavigationService();
                    }
                }
            }
        );
        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);

            await RefreshLists();
        }
        private async Task RefreshLists()
        {
            var products = await _productService.Get();
            Products = new ObservableCollection<Product>(products);
        }

    }
}
