using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class TransactionViewModel : FreshBasePageModel
    {
        private readonly IProductService _productService;
        public TransactionViewModel(IProductService productService)
        {
            _productService = productService;
        }
        #region Properties
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged(nameof(SelectedProduct));
            }
        }
        #endregion
        #region Commands
        public ICommand BackToHomePage => new Command(
            async () =>
            {
                await CoreMethods.PopToRoot(true);
            });
        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);
            SelectedProduct = await _productService.Get((initData as Product).Id);

        }


    }
}
