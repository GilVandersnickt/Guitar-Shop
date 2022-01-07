using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ShoppingCartViewModel : FreshBasePageModel
    {
        private readonly IProductService productService;

        public ShoppingCartViewModel()
        {
            productService = new ProductService();
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
        public ICommand OpenTransactionPage => new Command(
            async () =>
            {
                if (SelectedProduct != null)
                    await CoreMethods.PushPageModel<TransactionViewModel>(SelectedProduct);
            });
        public ICommand BackToMainPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<MainViewModel>();
            });
        #endregion

        public async override void Init(object initData)
        {
            base.Init(initData);
            SelectedProduct = await productService.Get((initData as Product).Id);

        }
    }
}
